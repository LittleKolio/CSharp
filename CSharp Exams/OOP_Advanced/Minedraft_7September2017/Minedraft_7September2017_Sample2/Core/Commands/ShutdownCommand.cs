using System;
using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(
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
        string shutdown = string.Format(Constants.Shutdown,
            Environment.NewLine,
            this.providerController.TotalEnergyProduced,
            Environment.NewLine,
            this.harvesterController.OreProduced);

        return shutdown;

        //StringBuilder sb = new StringBuilder("System Shutdown" + Environment.NewLine);
        //sb.AppendLine(string.Format(Constants.TotalEnergyProduced, this.providerController.TotalEnergyProduced))
        //    .AppendLine(string.Format(Constants.TotalOreMined, this.harvesterController.OreProduced));

        //return sb.ToString().TrimEnd();
    }
}