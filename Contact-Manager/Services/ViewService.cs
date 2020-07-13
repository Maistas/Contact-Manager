using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using Contact_Manager.Exceptions;
using Contact_Manager.Models;
using Contact_Manager.Services.Interfaces;

namespace Contact_Manager.Services
{
    public class ViewService : IViewService
    {
        public void PrintContacts(IEnumerable<Contact> contacts)
        {
            if (!contacts.Any())
            {
                throw new ValidationException("The contact list is empty.");
            }
            var table = new ConsoleTable("Name", "Last Name", "Phone Number", "Address");
            foreach (var contact in contacts)
            {
                table.AddRow(contact.Name, contact.LastName, contact.PhoneNumber, contact.Address);
            }
            table.Write();
            Console.WriteLine();
        }
        
        public void ShowUnknownError()
        {
            Console.WriteLine("An unknown error has occured. Please contact our non-existent support.");
        }

        public void ShowKnownError(ValidationException e)
        {
            Console.WriteLine(e.Message);
        }

        public void PrintSuccessNotification()
        {
            Console.WriteLine("Success!");
        }
    }
}