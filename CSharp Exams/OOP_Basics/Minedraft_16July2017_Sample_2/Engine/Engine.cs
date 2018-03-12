using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        string input;
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            List<string> arguments = InputParser.SplitInput(input, " ");

            string command = arguments[0];
            arguments = arguments.Skip(1).ToList();

            string result = string.Empty;

            switch (command)
            {
                case "RegisterHarvester": result = this.draftManager.RegisterHarvester(arguments); break;
                case "RegisterProvider": result = this.draftManager.RegisterProvider(arguments); break;
                case "Day": result = this.draftManager.Day(); break;
                case "Mode": result = this.draftManager.Mode(arguments); break;
                case "Check": result = this.draftManager.Check(arguments); break;
                case "Shutdown": result = this.draftManager.ShutDown(); break;
                default: break;
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }
        }
    }
}