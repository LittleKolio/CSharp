using System.Collections.Generic;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    protected InspectCommand(
        IList<string> arguments,
        IHarvesterController harvesterController,
        IProviderController providerController) 
        : base(arguments)
    {
    }

    public override string Execute()
    {
        string harvester = this.harvesterController.Entities
    }
}