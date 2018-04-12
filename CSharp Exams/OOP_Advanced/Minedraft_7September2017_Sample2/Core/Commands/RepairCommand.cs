using System.Collections.Generic;

public class RepairCommand : Command
{
    private IProviderController providerController;

    protected RepairCommand(IList<string> arguments, IProviderController providerController) 
        : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        throw new System.NotImplementedException();
    }
}