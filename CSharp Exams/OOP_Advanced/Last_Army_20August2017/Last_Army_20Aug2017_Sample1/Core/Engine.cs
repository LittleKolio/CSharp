using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private GameController gameController;

    public Engine(GameController gameController)
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

            try
            {
                gameController.GiveInputToGameController(tokens);
            }
            catch (ArgumentException arg)
            {
                //result.AppendLine(arg.Message);
            }
            catch (Exception ex)
            {
                ConsoleWriter.WriteLine(ex.Message);
            }
        }
    }

    private string[] SplitInput(string input, string delimiter)
    {
        return input.Split(delimiter.ToCharArray(), 
            StringSplitOptions.RemoveEmptyEntries);
    }
}
