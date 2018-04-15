using System;
using System.Collections.Generic;
using System.Linq;

public class WearHouse : IWearHouse
{
    private Dictionary<string, int> ammunitions;

    public WearHouse()
    {
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
        if (!this.ammunitions.ContainsKey(ammunition))
        {
            return false;
        }

        this.ammunitions[ammunition]--;

        if (this.ammunitions[ammunition] == 0)
        {
            this.ammunitions.Remove(ammunition);
        }

        return true;
    }

    public bool AmmunitionsNeeded(string[] ammunitionsNeeded)
    {
        return ammunitionsNeeded.All(a => this.ammunitions.ContainsKey(a));
    }
}
