using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private ConsoleReader inputReader;
    private ConsoleWriter outputWriter;
    private InputParser inputParser;
    private DraftManager draftManager;

    public Engine()
    {
        this.inputReader = new ConsoleReader();
        this.outputWriter = new ConsoleWriter();
        this.inputParser = new InputParser();
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        string input;
        while (!(input = this.inputReader.ReadLine())
            .Equals(Constants.INPUT_TERMINAOR))
        {
            List<string> commands = this.inputParser.ParseInput(input);
            this.DispatchCommands(commands);
        }
        string result = this.draftManager.ShutDown();
        this.outputWriter.WriteLine(result);
    }

    private void DispatchCommands(List<string> commands)
    {
        string command = commands[0];
        commands.Remove(command);
        string result = string.Empty;

        switch (command)
        {
            case "RegisterHarvester":
                result = this.draftManager.RegisterHarvester(commands);
                break;
            case "RegisterProvider":
                result = this.draftManager.RegisterProvider(commands);
                break;
            case "Day":
                result = this.draftManager.Day();
                break;
            case "Mode":
                result = this.draftManager.Mode(commands);
                break;
            case "Check":
                result = this.draftManager.Check(commands);
                break;
        }

        this.outputWriter.WriteLine(result);
    }
}
