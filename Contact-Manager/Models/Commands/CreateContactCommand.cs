using Contact_Manager.Exceptions;

namespace Contact_Manager.Models.Commands
{
    public class CreateContactCommand : Command
    {
        public Contact Contact { get; private set; }
        
        protected override void Parse(string[] commandLine)
        {
            if (commandLine.Length != 3 && commandLine.Length != 4)
            {
                throw new ValidationException("Unrecognised format. Please type in contact's name, last name, phone number and (optionally) address after the command.");
            }
            
            Contact = new Contact()
            {
                Name = commandLine[0],
                LastName = commandLine[1],
                PhoneNumber = commandLine[2],
                Address = commandLine.Length == 4 ? commandLine[3] : null
            };
        }
    }
}