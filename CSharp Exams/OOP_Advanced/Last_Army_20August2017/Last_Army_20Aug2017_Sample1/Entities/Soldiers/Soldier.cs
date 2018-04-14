using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    //public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    private const double maxEndurance = 100;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.OverallSkill = age + experience;
    }

    public int Age { get; private set; }

    public string Name { get; private set; }

    private double endurance;
    public double Endurance
    {
        get { return this.endurance; }
        protected set
        {
            this.endurance = Math.Min(maxEndurance, value);
        }
    }

    public double Experience { get; private set; }

    public double OverallSkill { get; protected set; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons { get; private set; }

    public void CompleteMission(IMission mission)
    {
        this.DecreaseAmmunitionWearLevel(mission.WearLevelDecrement);
    }

    private void DecreaseAmmunitionWearLevel(double missionWearLevelDecrement)
    {
        foreach (string weaponName in this.Weapons.Keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        bool enoughEndurance = this.Endurance < mission.EnduranceRequired;

        if (enoughEndurance)
            return false;

        bool neededAmmunitions = 
            this.Weapons.Values.Count(w => w != null) != 
            this.WeaponsAllowed.Count();

        if (neededAmmunitions)
            return false;

        bool positiveWearLevel = 
            this.Weapons.Values.Count(w => w.WearLevel < 0) != 
            this.WeaponsAllowed.Count();

        if (positiveWearLevel)
            return false;

        return true;
    }

    public abstract void Regenerate();
}