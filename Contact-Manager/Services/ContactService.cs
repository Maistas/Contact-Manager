using Contact_Manager.Models;
using Contact_Manager.Repositories.Interfaces;
using Contact_Manager.Services.Interfaces;

namespace Contact_Manager.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository contactRepository;
        
        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        
        public void AddContact(Contact contact)
        {
            contactRepository.Add(contact);
        }
    }
}