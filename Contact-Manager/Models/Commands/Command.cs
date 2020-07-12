using System;

namespace Contact_Manager.Models.Commands
{
    public abstract class Command
    {
        protected virtual void Parse(string[] commandLine) {}

        public static Command Create(string commandLine)
        {
            var input = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Command command = input[0] switch
            {
                "create-contact" => new CreateContactCommand(),
                "view-contacts" => new ViewAllContactsCommand(),
                _ => throw new InvalidOperationException()
            };
            command.Parse(input[1..]);
            return command;
        }
    }
}