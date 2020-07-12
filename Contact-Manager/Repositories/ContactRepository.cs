using System;
using System.IO;
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

        private string ContactToString(Contact contact)
        {
            return $"{contact.Name};{contact.LastName};{contact.PhoneNumber};{contact.Address ?? ""}{Environment.NewLine}";
        }
    }
}