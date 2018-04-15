using System;
using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;
    private const double increaseEndurance = 30;

    public override IReadOnlyList<string> WeaponsAllowed => new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "RPG",
        "Helmet",
        "Knife",
        "NightVision"
    };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        base.OverallSkill *= OverallSkillMiltiplier;
    }

    public override void Regenerate()
    {
        base.Endurance += base.Age + increaseEndurance;
    }
}