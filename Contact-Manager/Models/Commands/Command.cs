using System;

namespace Contact_Manager.Models.Commands
{
    public abstract class Command
    {
        protected abstract void Parse(string[] commandLine);

        public static Command Create(string commandLine)
        {
            var input = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var command = input[0] switch
            {
                "create-contact" => new CreateContactCommand(),
                _ => throw new InvalidOperationException()
            };
            command.Parse(input[1..]);
            return command;
        }
    }
}