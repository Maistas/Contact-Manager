using System.Collections.Generic;
using System.Linq;
using Contact_Manager.Exceptions;
using Contact_Manager.Models;
using Contact_Manager.Repositories.Interfaces;
using Contact_Manager.Services.Interfaces;

namespace Contact_Manager.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private List<Contact> _contacts;
        
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        public void AddContact(Contact contact)
        {
            if (_contacts != null && _contacts.Exists(x => string.CompareOrdinal(x.PhoneNumber, contact.PhoneNumber) == 0))
            {
                throw new ValidationException("Contact with the same phone number already exists.");
            }
            _contactRepository.Add(contact);
            _contacts = _contactRepository.GetAll();
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts ??= _contactRepository.GetAll();
        }

        public void DeleteContact(string phoneNumber)
        {
            if (_contacts == null || _contacts.Count < 1)
            {
                throw new ValidationException("The contacts list is empty. There is nothing to delete.");
            }
            
            var contact = _contacts.SingleOrDefault(x => string.CompareOrdinal(x.PhoneNumber, phoneNumber) == 0);
            
            if (contact == null)
            {
                throw new ValidationException("The contact does not exist in the contact list. Please type in an existing contact's phone number.");
            }
            
            _contactRepository.Delete(contact);
            _contacts.Remove(contact);
        }

        public void UpdateContact(string updatePhoneNumber, Contact updateContact)
        {
            if (_contacts == null || !_contacts.Any())
            {
                throw new ValidationException("The contacts list is empty. There is nothing to update.");
            }
            var oldContact = _contacts.Find(x => string.CompareOrdinal(x.PhoneNumber, updatePhoneNumber) == 0);
            var index = _contacts.IndexOf(oldContact);
            
            if (index == -1)
            {
                throw new ValidationException("The update contact does not exist in contact list.");
            }
            
            if(_contacts.Find(x => string.CompareOrdinal(x.PhoneNumber, updateContact.PhoneNumber) == 0 && _contacts.IndexOf(x) != index) != null)
            {
                throw new ValidationException("Cannot update contact's phone number since there already exists another contact with the same phone number in the contact list.");
            }

            _contacts[index] = updateContact;
            _contactRepository.Update(index, updateContact);
        }

        public void ClearData()
        {
            _contactRepository.Clear();
        }
    }
}