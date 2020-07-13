using System.Collections.Generic;
using Contact_Manager.Models;

namespace Contact_Manager.Repositories.Interfaces
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        
        List<Contact> GetAll();

        void Delete(Contact contact);

        void Update(int index, Contact contact);
        
        void Clear();
    }
}