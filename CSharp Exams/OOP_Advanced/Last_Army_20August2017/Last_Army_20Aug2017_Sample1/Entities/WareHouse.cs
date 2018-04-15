using System;
using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private AmmunitionFactory ammunitionFactory;
    private Dictionary<string, int> ammunitions;

    public WareHouse(AmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.ammunitions = new Dictionary<string, int>();
    }

    public void AddAmmunition(string ammunition, int amount)
    {
        if (!this.ammunitions.ContainsKey(ammunition))
        {
            this.ammunitions.Add(ammunition, 0);
        }

        this.ammunitions[ammunition] += amount;
    }



    public bool GetAmmonition(string ammunition)
    {
        if (!this.ammunitions.ContainsKey(ammunition) ||
            this.ammunitions[ammunition] == 0)
        {
            return false;
        }

        this.ammunitions[ammunition]--;

        return true;
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool equipped = true;

        IEnumerable<string> ammoNeeded = soldier.Weapons
            .Where(a => a.Value == null)
            .Select(a => a.Key);

        foreach (string ammo in ammoNeeded)
        {
            bool instock = this.GetAmmonition(ammo);

            if (!instock)
            {
                equipped = instock;
                continue;
            }

            soldier.Weapons[ammo] = this.ammunitionFactory.CreateAmmunition(ammo);
        }

        return equipped;
    }

    public void EquipArmy(IList<ISoldier> army)
    {
        foreach (ISoldier soldier in army)
        {
            this.TryEquipSoldier(soldier);
        }
    }
}
