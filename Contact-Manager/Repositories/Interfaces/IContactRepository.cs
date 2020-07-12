using Contact_Manager.Models;

namespace Contact_Manager.Repositories.Interfaces
{
    public interface IContactRepository
    {
        void Add(Contact contact);
    }
}