using System;
using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "Helmet"
    };

    public Ranker(
        string name, 
        int age, 
        double experience, 
        double endurance
        ) : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill
    {
        get { return base.OverallSkill * OverallSkillMiltiplier; }
    }

    public override void Regenerate()
    {
        base.Endurance = base.Endurance + 10 + this.Age;
    }
    public override void CompleteMission(IMission mission)
    {

    }

}