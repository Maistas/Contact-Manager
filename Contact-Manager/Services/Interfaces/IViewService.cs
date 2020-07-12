using System.Collections.Generic;
using Contact_Manager.Models;

namespace Contact_Manager.Services.Interfaces
{
    public interface IViewService
    {
        void PrintContacts(IEnumerable<Contact> contacts);
    }
}