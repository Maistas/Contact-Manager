namespace Contact_Manager.Exceptions
{
    public class UnknownCommandException : ValidationException
    {
        public UnknownCommandException() : base("Unknown command. Type \"help\" for all available commands.") {}
    }
}