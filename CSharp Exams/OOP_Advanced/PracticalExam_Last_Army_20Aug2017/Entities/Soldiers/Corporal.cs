using System;

public class Corporal : Soldier
{
    public Corporal(
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
