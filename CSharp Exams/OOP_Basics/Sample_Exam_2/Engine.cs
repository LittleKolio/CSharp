using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool running;
    private NationsBuilder nationBuilder;

    public Engine()
    {
        this.running = true;
        this.nationBuilder = new NationsBuilder();
    }

    public void Run()
    {
        while (this.running)
        {
            string input = this.ReadInput();
            List<string> commands = this.ParseInput(input);
            this.DistributeCommand(commands);
        }
    }
    private string ReadInput()
    {
        return Console.ReadLine();
    }
    private List<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, 
            StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
    private void DistributeCommand(List<string> commands)
    {
        string cmd = commands[0];
        commands.Remove(cmd);

        switch (cmd)
        {
            case "Bender":
                this.nationBuilder.AssignBender(commands);
                break;
            case "Monument":
                this.nationBuilder.AssignMonument(commands);
                break;
            case "Status":
                string strStats = this.nationBuilder.GetStatus(commands[0]);
                Console.WriteLine(strStats);
                break;
            case "War":
                this.nationBuilder.IssueWar(commands[0]);
                break;
            case "Quit":
                string strQuit = this.nationBuilder.GetWarsRecord();
                Console.WriteLine(strQuit);
                this.running = false;
                break;
        }
    }
}
