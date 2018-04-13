using System;
using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(
        IList<string> arguments,
        IHarvesterController harvesterController,
        IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string type = base.Arguments[0];
        IList<string> args = base.Arguments.Skip(1).ToList();

        switch (type)
        {
            case "Harvester": return this.harvesterController.Register(args);
            case "Provider": return this.providerController.Register(args);
            default: throw new ArgumentException("Invalide RegisterCommand!");
        }
    }
}