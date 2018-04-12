using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(
        IHarvesterController harvesterController,
        IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public IHarvesterController HarvesterController => this.harvesterController;

    public IProviderController ProviderController => this.providerController;

    public string ProcessCommand(IList<string> args)
    {
        string command = CultureInfo
            .CurrentCulture
            .TextInfo
            .ToTitleCase(args[0])
            + "Command";

        Type commandType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == command);

        if (commandType == null)
        {
            throw new ArgumentException(
                "Invalide CommandType!");
        }

        ParameterInfo[] cmdParams = commandType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public)
            .First()
            .GetParameters();

        PropertyInfo[] cmdInterpreterParams = this
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public);

        object[] cmdParamsToPass = new object[cmdParams.Length];

        cmdParamsToPass[0] = args.Skip(1).ToList();

        for (int i = 1; i < cmdParams.Length; i++)
        {
            Type paramType = cmdParams[i].ParameterType;

            cmdParamsToPass[i] = cmdInterpreterParams
                .FirstOrDefault(p => p.PropertyType == paramType)
                .GetValue(this);
        }


        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(
                "CommandType don't inherit ICommand!");
        }

        ICommand commandExecute = (ICommand)Activator.CreateInstance(
            commandType, cmdParamsToPass);

        return commandExecute.Execute();
    }
}