namespace EFCommandPattern
{
    using System;

    public class GreetingCommand : Command
    {
        public override void Execute()
        {
            Console.WriteLine("Hello emiiii ... tolkos");
        }
    }
}
