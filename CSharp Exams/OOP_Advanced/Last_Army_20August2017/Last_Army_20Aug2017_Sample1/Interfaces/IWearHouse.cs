using System.Collections.Generic;

public interface IWearHouse
{
    //IReadOnlyDictionary<string, int> Ammunitions { get; }

    void AddAmmunition(string ammunition, int amount);

    bool GetAmmonition(string ammunition)
}