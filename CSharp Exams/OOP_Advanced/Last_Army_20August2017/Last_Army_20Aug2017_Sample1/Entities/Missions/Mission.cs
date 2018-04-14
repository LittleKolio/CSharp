using System;

public abstract class Mission : IMission
{
    protected Mission(
        double scoreToComplete, 
        double enduranceRequired,
        double wearLevelDecrement)
    {
        this.ScoreToComplete = scoreToComplete;
        this.EnduranceRequired = enduranceRequired;
        this.WearLevelDecrement = wearLevelDecrement;
    }

    public double EnduranceRequired { get; private set; }

    public string Name => this.GetType().Name;

    public double ScoreToComplete { get; private set; }

    public double WearLevelDecrement { get; private set; }
}