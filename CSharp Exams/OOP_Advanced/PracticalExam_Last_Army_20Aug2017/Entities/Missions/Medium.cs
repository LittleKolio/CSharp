using System;

public class Medium : Mission
{
    private const double MediumEnduranceRequired = 50;

    public Medium(string name, double scoreToComplete) 
        : base(name, scoreToComplete)
    {
    }

    public override double EnduranceRequired
    {
        get { return MediumEnduranceRequired; }
    }
}