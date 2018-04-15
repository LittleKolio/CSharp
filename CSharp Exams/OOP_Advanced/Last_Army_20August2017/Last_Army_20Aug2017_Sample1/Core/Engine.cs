using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private IGameController gameController;

    public Engine(IGameController gameController)
    {
        this.gameController = gameController;
    }

    public void Run()
    {
        string input;
        while (!(input = ConsoleReader.ReadLine())
            .Equals(Message.InputTerminateString))
        {
            string[] tokens = SplitInput(input, " ");

            string result = string.Empty;

            try
            {
                this.gameController.GiveInputToGameController(tokens);
            }
            //catch (ArgumentException arg)
            //{
            //    ConsoleWriter.WriteLine(arg.Message);
            //}
            catch (Exception ex)
            {
                ConsoleWriter.WriteLine(ex.Message);
            }
        }

        this.gameController.RequestResult();
    }

    private string[] SplitInput(string input, string delimiter)
    {
        return input.Split(delimiter.ToCharArray(), 
            StringSplitOptions.RemoveEmptyEntries);
    }
}
