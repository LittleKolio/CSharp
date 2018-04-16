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
    }

    public override string Execute()
    {
        StringBuilder sb = new StringBuilder("System Shutdown" + Environment.NewLine);
        sb.AppendLine(string.Format(Constants.TotalEnergyProduced, this.providerController.TotalEnergyProduced))
            .AppendLine(string.Format(Constants.TotalOreMined, this.harvesterController.OreProduced));

        return sb.ToString().TrimEnd();
    }
}