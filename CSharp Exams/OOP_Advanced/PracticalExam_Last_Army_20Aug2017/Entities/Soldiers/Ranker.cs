using System;

public class Ranker : Soldier
{
    public Ranker(
        string name, 
        int age, 
        double experience, 
        double endurance
        ) : base(name, age, experience, endurance)
    {
    }

    public override void Regenerate()
    {

    }
    public override void CompleteMission(IMission mission)
    {

    }

}