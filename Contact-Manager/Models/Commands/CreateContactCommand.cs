namespace Contact_Manager.Models.Commands
{
    public class CreateContactCommand : Command
    {
        public Contact Contact { get; private set; }
        
        protected override void Parse(string[] commandLine)
        {
            Contact = new Contact()
            {
                Name = commandLine[0],
                LastName = commandLine[1],
                PhoneNumber = commandLine[2],
                Address = commandLine[3]
            };
        }
    }
}