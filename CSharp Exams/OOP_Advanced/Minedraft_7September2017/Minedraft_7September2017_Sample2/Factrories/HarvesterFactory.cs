using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];
        int id = int.Parse(args[1]);
        double oreOutput = double.Parse(args[2]);
        double energyReq = double.Parse(args[3]);

        Type harvesterType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + "Harvester");

        if (harvesterType == null)
        {
            throw new ArgumentException(
                "Invalid HarvesterType!");
        }

        if (!typeof(IHarvester).IsAssignableFrom(harvesterType))
        {
            throw new InvalidOperationException(
                "HarvesterType don't inherit IHarvester!");
        }

        //var ctors = harvesterType.GetConstructors(
        //    BindingFlags.Public | BindingFlags.Instance);

        object[] parameters = new object[] { id, oreOutput, energyReq };

        IHarvester harvester = (IHarvester)Activator.CreateInstance(
            harvesterType, parameters);

        return harvester;
    }
}