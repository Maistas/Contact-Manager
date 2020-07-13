using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Contact_Manager.Exceptions;
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
            if (!File.Exists(_path) || !File.ReadAllLines(_path).Any())
            {
                throw new ValidationException("The contact list is empty.");
            }    
            return File.ReadAllLines(_path).Select(ParseContact).ToList();
        }

        private static string ContactToString(Contact contact)
        {
            return
                $"{contact.Name};{contact.LastName};{contact.PhoneNumber};{contact.Address ?? ""}{Environment.NewLine}";
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

        public void Delete(Contact contact)
        {
            var readText = File.ReadAllLines(_path);
            File.WriteAllText(_path, string.Empty);
            using var writer = new StreamWriter(_path);
            foreach (var s in readText)
            {
                if (string.CompareOrdinal(ContactToString(contact), s + $"{Environment.NewLine}") != 0)
                {
                    writer.WriteLine(s);
                }
            }
        }
    }
}