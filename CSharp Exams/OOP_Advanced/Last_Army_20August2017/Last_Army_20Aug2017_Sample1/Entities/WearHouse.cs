using System;
using System.Collections.Generic;

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

        if (this.ammunitions[ammunition] == 0)
        {
            return false;
        }

        this.ammunitions[ammunition]--;

        return true;
    }
}
