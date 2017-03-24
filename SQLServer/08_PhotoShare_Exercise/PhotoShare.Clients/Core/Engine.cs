namespace PhotoShare.Clients.Core
{
    using System;

    public class Engine
    {
        private readonly CommandDispatcher commandDispatcher;

        public Engine(CommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Trim();
                    string[] cmdParam = input.Split(new char[] { ' ' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                    var result = this.commandDispatcher
                        .DispatchCommand(cmdParam)
                        .Execute();

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
