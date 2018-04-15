using System;

public abstract class Mission : IMission
{
    protected Mission(
        double scoreToComplete, 
        double enduranceRequired,
        double wearLevelDecrement,
        string name)
    {
        this.ScoreToComplete = scoreToComplete;
        this.EnduranceRequired = enduranceRequired;
        this.WearLevelDecrement = wearLevelDecrement;
        this.Name = name;
    }

    public double EnduranceRequired { get; private set; }

    public string Name { get; }

    public double ScoreToComplete { get; private set; }

    public double WearLevelDecrement { get; private set; }
}