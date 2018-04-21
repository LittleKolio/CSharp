using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private HeroManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, HeroManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();

            List<string> arguments = this.ParseInput(inputLine, " ");

            string result = string.Empty;
            try
            {
                result = this.ProcessInput(arguments);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            if (string.IsNullOrEmpty(result))
            {
                this.writer.WriteLine(result);
            }

            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> ParseInput(string input, string delimiter)
    {
        return input.Split(delimiter.ToCharArray(), 
            StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ProcessInput(List<string> arguments)
    {
        string command = arguments[0] + "Command";
        arguments.RemoveAt(0);

        Type commandType = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == command);

        if (commandType == null)
        {
            throw new ArgumentException(
                "Invalid Command!");
        }

        ICommand cmd = (ICommand)Activator.CreateInstance(commandType, new object[] { });

        return cmd.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}