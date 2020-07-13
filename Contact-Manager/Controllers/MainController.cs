using Contact_Manager.Controllers.Interfaces;
using Contact_Manager.Exceptions;
using Contact_Manager.Models.Commands;
using Contact_Manager.Services.Interfaces;

namespace Contact_Manager.Controllers
{
    public class MainController : IMainController
    {
        private readonly IContactService _contactService;
        private readonly IViewService _viewService;

        public MainController(IContactService contactService, IViewService viewService)
        {
            _contactService = contactService;
            _viewService = viewService;
        }

        public void AddContact(CreateContactCommand command)
        {
            _contactService.AddContact(command.Contact);
            _viewService.PrintSuccessNotification();
        }

        public void ViewContacts()
        {
            _viewService.PrintContacts(_contactService.GetAllContacts());
        }

        public void ShowUnknownError()
        {
            _viewService.ShowUnknownError();
        }

        public void ShowKnownError(ValidationException e)
        {
            _viewService.ShowKnownError(e);
        }

        public void DeleteContact(DeleteContactCommand command)
        {
            _contactService.DeleteContact(command.PhoneNumber);
            _viewService.PrintSuccessNotification();
        }

        public void UpdateContact(UpdateContactCommand updateCommand)
        {
            _contactService.UpdateContact(updateCommand.PhoneNumber, updateCommand.Contact);
        }

        public void ViewHelp()
        {
            _viewService.ShowHelpDialog();
        }

        public void ClearDataFile()
        {
            _contactService.ClearData();
        }
    }
}