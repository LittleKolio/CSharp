using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(
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
        int id = int.Parse(base.Arguments[0]);

        IEntity harvester = this.harvesterController
            .Entities
            .FirstOrDefault(h => h.ID == id);

        if (harvester != null)
        {
            return harvester.ToString();
        }

        IEntity provider = this.providerController
            .Entities
            .FirstOrDefault(p => p.ID == id);

        if (provider != null)
        {
            return provider.ToString();
        }

        return string.Format(Constants.NoEntity, id);
    }
}