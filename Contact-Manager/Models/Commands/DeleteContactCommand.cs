using Contact_Manager.Exceptions;

namespace Contact_Manager.Models.Commands
{
    public class DeleteContactCommand : Command
    {
        public string PhoneNumber { get; set; }

        protected override void Parse(string[] commandLine)
        {
            if (commandLine.Length != 1)
            {
                throw new ValidationException("Unrecognised format. Please type in contact's phone number after the command.");
            }

            PhoneNumber = commandLine[0];
        }
    }
}