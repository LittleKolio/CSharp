using System.Collections.Generic;

public abstract class AbstractCommand : IExecutable
{
    public AbstractCommand(List<string> arguments)
    {
        this.Arguments = arguments;
    }

    public List<string> Arguments { get; protected set; }

    public abstract string Execute();
}