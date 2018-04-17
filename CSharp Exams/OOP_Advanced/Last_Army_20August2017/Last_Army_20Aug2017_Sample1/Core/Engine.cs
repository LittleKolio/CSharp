using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private IGameController gameController;
    private IReader reader;
    private IWriter writer;

    public Engine(IGameController gameController, IReader reader, IWriter writer)
    {
        this.gameController = gameController;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        string input;
        while (!(input = this.reader.ReadLine())
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
                this.writer.WriteLine(ex.Message);
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
