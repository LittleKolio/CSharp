using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            IList<string> args = this.SplitInput(Console.ReadLine(), " ");
            string result = string.Empty;
            try
            {
                result = this.commandInterpreter
                    .ProcessCommand(args);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
        }
    }

    private IList<string> SplitInput(string input, string delimiter)
    {
        return input
            .Split(delimiter.ToCharArray(), 
                StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
}
