using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Contact_Manager.Models;
using Contact_Manager.Repositories.Interfaces;

namespace Contact_Manager.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _path = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}Data.txt";
        
        public void Add(Contact contact)
        {
            File.AppendAllText(_path, ContactToString(contact), Encoding.UTF8);
        }

        public List<Contact> GetAll()
        {
            return File.ReadAllLines(_path).Select(ParseContact).ToList();
        }

        private static string ContactToString(Contact contact)
        {
            return $"{contact.Name};{contact.LastName};{contact.PhoneNumber};{contact.Address ?? ""}{Environment.NewLine}";
        }

        private static Contact ParseContact(string line)
        {
            var splits = line.Split(';');
            return new Contact()
            {
                Name = splits[0],
                LastName = splits[1],
                PhoneNumber = splits[2],
                Address = splits.Length == 4 ? splits[3] : null
            };
        }
    }
}