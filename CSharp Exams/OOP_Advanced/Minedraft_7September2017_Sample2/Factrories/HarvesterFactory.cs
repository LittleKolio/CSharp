using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class HarvesterFactory
{
    public static IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];
        int id = int.Parse(args[1]);
        double oreOutput = double.Parse(args[2]);
        double energyReq = double.Parse(args[3]);

        Type clazz = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + "Harvester");

        if (clazz == null)
        {

        }

        var ctors = clazz.GetConstructors(
            BindingFlags.Public | BindingFlags.Instance);

        IHarvester harvester = (IHarvester)Activator.CreateInstance(
            clazz, new object[] { id, oreOutput, energyReq });

        return harvester;
    }
}