namespace Exercise_03_BarracksWars_A_New_Factory.Core
{
    using System;
    using System.Linq;
    using Contracts;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            string input;
            while (!(input = Console.ReadLine()).Equals("fight"))
            {
                try
                {
                    string[] data = input.Split();
                    string commandName = data[0];
                    data = data.Skip(1).ToArray();

                    string result = this.commandInterpreter
                        .InterpretCommand(data, commandName)
                        .Execute();

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        //private string InterpredCommand(string[] data, string commandName)
        //{
        //    string result = string.Empty;
        //    switch (commandName)
        //    {
        //        case "fight":
        //            Environment.Exit(0);
        //            break;
        //        default:
        //            throw new InvalidOperationException("Invalid command!");
        //    }
        //    return result;
        //}
    }
}
