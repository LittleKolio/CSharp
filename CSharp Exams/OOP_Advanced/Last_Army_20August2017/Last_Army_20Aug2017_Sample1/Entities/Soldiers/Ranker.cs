using System;
using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;
    private const double increaseEndurance = 10;

    protected override IReadOnlyList<string> WeaponsAllowed => new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
    };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        base.OverallSkill *= OverallSkillMiltiplier;
    }

    public override void Regenerate()
    {
        base.Endurance += base.Age + increaseEndurance;
    }
}