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
    private Manager manager;

    public Engine()
    {
        this.inputReader = new ConsoleReader();
        this.outputWriter = new ConsoleWriter();
        this.inputParser = new InputParser();
        this.manager = new Manager();
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
    }

    private void DispatchCommands(List<string> commands)
    {
        string command = commands[0];
        commands.Remove(command);

        switch (command)
        {
            case "xx":
                this.manager.Something(
                    commands[0]
                    );
                break;
            case "xxx":
                this.outputWriter.WriteLine(this.manager.WriteSomething());
                break;
        }
    }
}
