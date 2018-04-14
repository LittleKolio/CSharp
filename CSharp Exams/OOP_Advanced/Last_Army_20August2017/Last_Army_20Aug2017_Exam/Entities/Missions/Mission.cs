using System;

public abstract class Mission : IMission
{
    public Mission(
        string name, 
        double scoreToComplete)
    {
        this.Name = name;
        this.ScoreToComplete = scoreToComplete;
    }

    public abstract double EnduranceRequired { get; }

    public string Name { get; private set; }

    public double ScoreToComplete { get; private set; }

    public double WearLevelDecrement { get; private set; }
}