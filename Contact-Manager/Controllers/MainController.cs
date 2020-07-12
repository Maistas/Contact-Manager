using Contact_Manager.Controllers.Interfaces;
using Contact_Manager.Models.Commands;
using Contact_Manager.Services.Interfaces;

namespace Contact_Manager.Controllers
{
    public class MainController : IMainController
    {
        private IContactService contactService;

        public MainController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public void AddContact(CreateContactCommand command)
        {
            contactService.AddContact(command.Contact);
        }
    }
}