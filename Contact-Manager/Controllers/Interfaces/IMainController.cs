using Contact_Manager.Exceptions;
using Contact_Manager.Models.Commands;

namespace Contact_Manager.Controllers.Interfaces
{
    public interface IMainController
    {
        void AddContact(CreateContactCommand command);

        void ViewContacts();

        void ShowUnknownError();

        void ShowKnownError(ValidationException e);

        void DeleteContact(DeleteContactCommand command);
        
        void UpdateContact(UpdateContactCommand updateCommand);
    }
}