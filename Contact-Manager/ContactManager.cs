using System;
using Contact_Manager.Controllers;
using Contact_Manager.Controllers.Interfaces;
using Contact_Manager.Services;
using Contact_Manager.Services.Interfaces;
using SimpleInjector;

namespace Contact_Manager
{
    class ContactManager
    {
        private static void Main(string[] args)
        {
            var container = CreateContainer();
            var controller = container.GetInstance<IMainController>();
            Console.WriteLine(controller);
        }

        private static Container CreateContainer()
        {
            var container = new Container();
            container.Register<IMainController, MainController>();
            container.Register<IContactService, ContactService>();
            return container;
        }
    }
}