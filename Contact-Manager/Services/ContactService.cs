using System.Collections.Generic;
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
            _contactRepository.Add(contact);
            _contacts?.Add(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts ??= _contactRepository.GetAll();
        }
    }
}