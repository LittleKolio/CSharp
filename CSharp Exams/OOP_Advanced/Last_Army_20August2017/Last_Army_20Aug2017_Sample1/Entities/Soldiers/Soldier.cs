using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{

    private const double maxEndurance = 100;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        InitializeWeapons();
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

    public virtual double OverallSkill => this.Age + this.Experience;

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons { get; private set; }

    private void InitializeWeapons()
    {
        this.Weapons = new Dictionary<string, IAmmunition>(this.WeaponsAllowed.Count);
        foreach (string ammo in this.WeaponsAllowed)
        {
            this.Weapons.Add(ammo, null);
        }
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;
        this.DecreaseAmmunitionWearLevel(mission.WearLevelDecrement);
    }

    private void DecreaseAmmunitionWearLevel(double missionWearLevelDecrement)
    {
        IList<string> weaponNames = this.Weapons.Keys.ToList();

        foreach (string weaponName in weaponNames)
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
        bool enoughEndurance = this.Endurance >= mission.EnduranceRequired;

        if (!enoughEndurance)
            return false;

        bool neededAmmunitions = this.Weapons.Values.All(w => w != null);

        if (!neededAmmunitions)
            return false;

        return true;
    }

    public abstract void Regenerate();

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

}