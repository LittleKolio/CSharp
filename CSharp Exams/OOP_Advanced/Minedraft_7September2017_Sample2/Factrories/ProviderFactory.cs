﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
        int id = int.Parse(args[1]);
        string type = args[0];
        double energyOutput = double.Parse(args[2]);

        Type providerType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + "Provider");

        if (providerType == null)
        {
            throw new ArgumentException(
                "Invalid ProviderType!");
        }

        if (!typeof(IProvider).IsAssignableFrom(providerType))
        {
            throw new InvalidOperationException(
                "ProviderType don't inherit IProvider!");
        }

        //var ctors = providerType.GetConstructors(
        //    BindingFlags.Public | BindingFlags.Instance);

        object[] parameters = new object[] { id, energyOutput };

        IProvider provider = (IProvider)Activator.CreateInstance(providerType, parameters);

        return provider;
    }
}