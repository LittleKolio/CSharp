using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(
        string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type soldierType = Assembly
            .GetCallingAssembly()
            //.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == soldierTypeName);

        if (soldierType == null)
        {
            throw new ArgumentException(
                "Invalid SoldierType!");
        }

        if (!typeof(ISoldier).IsAssignableFrom(soldierType))
        {
            throw new InvalidOperationException(
                "SoldierType don't inherit ISoldier!");
        }

        object[] parameters = new object[]
        {
            name, age, experience, endurance
        };

        ISoldier soldier = (ISoldier)Activator.CreateInstance(
            soldierType, parameters);

        return soldier;
    }
}