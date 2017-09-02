using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private double endurance;

    public Soldier(
        string name, 
        int age, 
        double experience, 
        double endurance
        )
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
    }

    public abstract IDictionary<string, IAmmunition> Weapons { get; }

    public virtual double OverallSkill
    {
        get { return this.Age + this.Experience; }
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get { return this.endurance; }
        protected set
        {
            if (value <= 100)
            {
                this.endurance = value;
            }
            else if (value > 100)
            {
                this.endurance = 100;
            }
            else
            {
                throw new ArgumentException(
                    "Something is wrong : Endurance");
            }
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public abstract void Regenerate();

    public abstract void CompleteMission(IMission mission);

    public override string ToString() => string.Format(
        OutputMessages.SoldierToString,
        this.Name,
        this.OverallSkill
    );
}