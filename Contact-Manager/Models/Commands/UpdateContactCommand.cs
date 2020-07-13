using Contact_Manager.Exceptions;

namespace Contact_Manager.Models.Commands
{
    public class UpdateContactCommand : Command
    {
        public Contact Contact { get; set; }
        public string PhoneNumber { get; set; }
        
        protected override void Parse(string[] commandLine)
        {
            if (commandLine.Length != 4 && commandLine.Length != 5)
            {
                throw new ValidationException("Unrecognised format. Please type in previous contact's phone number" +
                                              " and new contact's name, last name, phone number and (optionally) address after the command.");
            }

            PhoneNumber = commandLine[0];
            
            Contact = new Contact()
            {
                Name = commandLine[1],
                LastName = commandLine[2],
                PhoneNumber = commandLine[3],
                Address = commandLine.Length == 5 ? commandLine[4] : null
            };
        }
    }
}