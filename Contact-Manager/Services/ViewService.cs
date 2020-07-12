using System;
using System.Collections.Generic;
using ConsoleTables;
using Contact_Manager.Models;
using Contact_Manager.Services.Interfaces;

namespace Contact_Manager.Services
{
    public class ViewService : IViewService
    {
        public void PrintContacts(IEnumerable<Contact> contacts)
        {
            var table = new ConsoleTable("Name", "Last Name", "Phone Number", "Address");
            foreach (var contact in contacts)
            {
                table.AddRow(contact.Name, contact.LastName, contact.PhoneNumber, contact.Address);
            }
            table.Write();
            Console.WriteLine();
        }
    }
}