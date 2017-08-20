using System;

public abstract class Mission : IMission
{
    public Mission(
        string name, 
        double enduranceRequired, 
        double scoreToComplete)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequired;
        this.ScoreToComplete = scoreToComplete;
    }

    public double EnduranceRequired { get; private set; }

    public string Name { get; private set; }

    public double ScoreToComplete { get; private set; }

    public double WearLevelDecrement { get; private set; }
}