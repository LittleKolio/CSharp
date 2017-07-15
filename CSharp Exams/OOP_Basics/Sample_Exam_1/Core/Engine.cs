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
    private CarManager carManager;

    public Engine()
    {
        this.inputReader = new ConsoleReader();
        this.outputWriter = new ConsoleWriter();
        this.inputParser = new InputParser();
        this.carManager = new CarManager();
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
            case "register":
                this.carManager.Register(
                    int.Parse(commands[0]), //id
                    commands[1], //type
                    commands[2], //brand
                    commands[3], //model
                    int.Parse(commands[4]), //yearOfProduction
                    int.Parse(commands[5]), //horsepower
                    int.Parse(commands[6]), //acceleration
                    int.Parse(commands[7]), //suspension
                    int.Parse(commands[8]) //durability
                    );
                break;

            case "open":
                this.carManager.Open(
                    int.Parse(commands[0]), //id
                    commands[1], //type
                    int.Parse(commands[2]), //length
                    commands[3], //route
                    int.Parse(commands[4]) //prizePool
                    );
                break;

            case "participate":
                this.carManager.Participate(
                    int.Parse(commands[0]), //carId
                    int.Parse(commands[1]) //raceId
                    );
                break;

            case "check":
                this.outputWriter.WriteLine(this.carManager.Check(
                    int.Parse(commands[0]) //carId
                    ));
                break;

            case "start":
                this.outputWriter.WriteLine(this.carManager.Start(
                    int.Parse(commands[0]) //raceId
                    ));
                break;

            case "park":
                this.carManager.Park(
                    int.Parse(commands[0]) //carId
                    );
                break;

            case "unpark":
                this.carManager.Unpark(
                    int.Parse(commands[0]) //carId
                    );
                break;

            case "tune":
                this.carManager.Tune(
                    int.Parse(commands[0]), //index
                    commands[1] // AddOn
                    );
                break;
        }
    }
}
