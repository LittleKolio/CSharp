namespace EFCommandPattern
{
    using System;

    public class CommandNotFound : Command
    {
        public override void Execute()
        {
            Console.WriteLine("Command not found!");
        }
    }
}
