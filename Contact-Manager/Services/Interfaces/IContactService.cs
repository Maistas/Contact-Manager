using System.Collections.Generic;
using Contact_Manager.Models;

namespace Contact_Manager.Services.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        
        List<Contact> GetAllContacts();

        void DeleteContact(string phoneNumber);
        
        void UpdateContact(string updateCommandPhoneNumber, Contact updateCommandContact);
        
        void ClearData();
    }
}