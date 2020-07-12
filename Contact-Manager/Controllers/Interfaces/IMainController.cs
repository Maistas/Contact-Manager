using Contact_Manager.Models.Commands;

namespace Contact_Manager.Controllers.Interfaces
{
    public interface IMainController
    {
        void AddContact(CreateContactCommand command);

        void ViewContacts();
    }
}