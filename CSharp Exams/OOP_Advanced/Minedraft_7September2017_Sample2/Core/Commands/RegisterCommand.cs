using System.Collections.Generic;

public class RegisterCommand : Command
{
    private IHarvesterFactory harvesterFactory;
    private IProviderFactory providerFactory;

    protected RegisterCommand(
        IEnumerable<string> arguments, 
        IHarvesterFactory harvesterFactory, 
        IProviderFactory providerFactory) 
        : base(arguments)
    {
    }

    public override string Execute()
    {
        throw new System.NotImplementedException();
    }
}