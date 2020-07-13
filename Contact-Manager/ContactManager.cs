using System;
using Contact_Manager.Controllers;
using Contact_Manager.Controllers.Interfaces;
using Contact_Manager.Exceptions;
using Contact_Manager.Models.Commands;
using Contact_Manager.Repositories;
using Contact_Manager.Repositories.Interfaces;
using Contact_Manager.Services;
using Contact_Manager.Services.Interfaces;
using SimpleInjector;

namespace Contact_Manager
{
    internal static class ContactManager
    {
        private static void Main()
        {
            var container = CreateContainer();
            var controller = container.GetInstance<IMainController>();
            while (true)
            {
                var input = Console.ReadLine();
                try
                {
                    var command = Command.Create(input);
                    switch (command)
                    {
                        case CreateContactCommand createCommand:
                            controller.AddContact(createCommand);
                            break;
                        case ViewAllContactsCommand _:
                            controller.ViewContacts();
                            break;
                        case QuitCommand _:
                            return;
                        case DeleteContactCommand deleteCommand:
                            controller.DeleteContact(deleteCommand);
                            break;
                        case UpdateContactCommand updateCommand:
                            controller.UpdateContact(updateCommand);
                            break;
                        default:
                            throw new UnknownCommandException();
                    }
                }
                catch (ValidationException e)
                {
                    controller.ShowKnownError(e);
                }
                catch
                {
                    controller.ShowUnknownError();
                }
            }
        }

        private static Container CreateContainer()
        {
            var container = new Container();
            container.Register<IMainController, MainController>();
            container.Register<IContactService, ContactService>();
            container.Register<IContactRepository, ContactRepository>();
            container.Register<IViewService, ViewService>();
            return container;
        }
    }
}