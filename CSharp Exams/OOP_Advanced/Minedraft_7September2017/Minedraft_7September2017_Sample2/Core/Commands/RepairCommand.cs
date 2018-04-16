using System.Collections.Generic;

public class RepairCommand : Command
{
    private IProviderController providerController;

    protected RepairCommand(
        IList<string> arguments, 
        IProviderController providerController) 
        : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int id = int.Parse(base.Arguments[0]);
        double value = double.Parse(base.Arguments[1]);

        return this.providerController.Repair(id, value);
    }
}