using System;
using Contact_Manager.Exceptions;

namespace Contact_Manager.Models.Commands
{
    public abstract class Command
    {
        protected virtual void Parse(string[] commandLine) {}

        public static Command Create(string commandLine)
        {
            var input = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if(input.Length == 0) throw new UnknownCommandException();
            
            Command command = input[0] switch
            {
                "create-contact" => new CreateContactCommand(),
                "view-contacts" => new ViewAllContactsCommand(),
                "quit" => new QuitCommand(),
                "delete-contact" => new DeleteContactCommand(),
                "update-contact" => new UpdateContactCommand(),
                _ => throw new UnknownCommandException()
            };
            command.Parse(input[1..]);
            return command;
        }
    }
}