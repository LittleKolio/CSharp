using System;
using System.Collections.Generic;

public class SoldiersFactory
{
    public ISoldier CreateSoldier(string type, string name, int age, double experience, double endurance)
    {
        Type typesoldierClass = Type.GetType(type);
        ISoldier soldier = (ISoldier)Activator.CreateInstance(
                typesoldierClass,
                new object[] { name, age, experience, endurance }
            );

        return soldier;
    }
}