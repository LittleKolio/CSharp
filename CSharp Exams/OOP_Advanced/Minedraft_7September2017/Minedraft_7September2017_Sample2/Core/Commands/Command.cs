using System.Collections;
using System.Collections.Generic;

public abstract class Command : ICommand
{
    private IList<string> arguments;

    protected Command(IList<string> arguments)
    {
        this.arguments = new List<string>(arguments);
    }

    public IList<string> Arguments => this.arguments;

    public abstract string Execute();
}