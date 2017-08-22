using System;
using System.Text;

public class Engine
{
    private const string Terminator = "Enough! Pull back!";
    private GameController gameController;
    private StringBuilder result;

    public Engine(GameController gameController)
    {
        this.gameController = gameController;
        this.result = new StringBuilder();
    }

    public void Run()
    {
        string input;
        while ((input = ConsoleReader.ReadLine())
            .Equals(Terminator))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                result.AppendLine(arg.Message);
            }
        }

        //gameController.RequestResult(result);
        ConsoleWriter.WriteLine(result.ToString());
    }
}