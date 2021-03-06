﻿using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammunitionType = Assembly
            .GetCallingAssembly()
            //.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == ammunitionName);

        if (ammunitionType == null)
        {
            throw new ArgumentException(
                "Invalid AmmunitionType!");
        }

        if (!typeof(IAmmunition).IsAssignableFrom(ammunitionType))
        {
            throw new InvalidOperationException(
                "AmmunitionType don't inherit IAmmunition!");
        }

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(ammunitionType);

        return ammunition;
    }
}