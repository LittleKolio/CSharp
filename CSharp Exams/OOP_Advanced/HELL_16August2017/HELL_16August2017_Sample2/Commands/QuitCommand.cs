using System;
using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    private IManager manager;

    public QuitCommand(List<string> arguments, IManager manager) : base (arguments)
    {
        this.manager = manager;
    }

    public override string Execute()
    {
        //return this.manager.Quit(this.ArgsList);
        return null;
    }
}