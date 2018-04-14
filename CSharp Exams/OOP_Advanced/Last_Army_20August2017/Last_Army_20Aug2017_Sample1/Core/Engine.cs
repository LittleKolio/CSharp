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
            .Equals("Enough! Pull back!"))
        {
            string[] tokens = SplitInput(input, " ");

            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                result.AppendLine(arg.Message);
            }
            input = ConsoleReader.ReadLine();
        }
    }

    private string[] SplitInput(string input, string delimiter)
    {
        return input.Split(delimiter.ToCharArray(), 
            StringSplitOptions.RemoveEmptyEntries);
    }
}
