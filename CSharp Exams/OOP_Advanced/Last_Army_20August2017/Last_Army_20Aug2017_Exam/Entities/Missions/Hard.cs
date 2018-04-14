using System;

public class Hard : Mission
{
    private const double HardEnduranceRequired = 80;

    public Hard(string name, double scoreToComplete) 
        : base(name, scoreToComplete)
    {
    }

    public override double EnduranceRequired
    {
        get { return HardEnduranceRequired; }
    }
}