using System;
using System.Collections.Generic;

public class SoldiersFactory
{
    public ISoldier CreateSoldier(IList<string> arguments)
    {
        string soldierClassName = arguments[0];
        arguments.Remove(soldierClassName);

        Type typesoldierClass = Type.GetType(soldierClassName);
        ISoldier soldier = (ISoldier)Activator.CreateInstance(
                typesoldierClass,
                new object[] 
                {
                    arguments[0],               // name
                    int.Parse(arguments[1]),    // age
                    double.Parse(arguments[2]), // experience
                    double.Parse(arguments[3])  // endurance
                }
            );

        return soldier;
    }
}