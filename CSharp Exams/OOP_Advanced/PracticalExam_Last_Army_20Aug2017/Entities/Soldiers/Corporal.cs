using System;
using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;
    private IDictionary<string, IAmmunition> weapons = new Dictionary<string, IAmmunition>
    {
        { "Gun", new Gun("Gun") },
        { "AutomaticMachine", new AutomaticMachine("AutomaticMachine") },
        { "MachineGun", new MachineGun("MachineGun") },
        { "Helmet", new Helmet("Helmet") },
        { "Knife", new Knife("Knife") }
    };

    public Corporal(
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

    public override IDictionary<string, IAmmunition> Weapons
    {
        get { return this.weapons; }
    }

    public override void Regenerate()
    {
        base.Endurance = base.Endurance + 10 + this.Age;
    }

    public override void CompleteMission(IMission mission)
    {

    }
}
