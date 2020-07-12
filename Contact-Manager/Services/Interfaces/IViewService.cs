using System.Collections.Generic;
using Contact_Manager.Exceptions;
using Contact_Manager.Models;

namespace Contact_Manager.Services.Interfaces
{
    public interface IViewService
    {
        void PrintContacts(IEnumerable<Contact> contacts);
        
        void ShowUnknownError();

        void ShowKnownError(ValidationException e);

        void PrintSuccessNotification();
    }
}