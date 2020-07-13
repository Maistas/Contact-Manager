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

        public void ShowHelpDialog()
        {
            Console.WriteLine("Welcome to Contact Manager!");
            Console.WriteLine("To create a contact type \"create-contact name lastname phonenumber\" or \"create-contact name lastname phonenumber address\".");
            Console.WriteLine("To update a contact type \"update-contact contactphonenumber newname newlastname newphonenumber\" or" +
                              " \"update-contact contactphonenumber newname newlastname newphonenumber newaddress\".");
            Console.WriteLine("To delete a contact type \"delete-contact phonenumber\" to delete the contact with the corresponding phone number.");
            Console.WriteLine("To view the contact list type \"view-contacts\".");
            Console.WriteLine("To quit the application type \"quit\".");
            Console.WriteLine("You can find this help dialog by typing \"help\".");
        }
    }
}