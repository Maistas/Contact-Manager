using Contact_Manager.Controllers.Interfaces;
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
        }

        public void ViewContacts()
        {
            _viewService.PrintContacts(_contactService.GetAllContacts());
        }
    }
}