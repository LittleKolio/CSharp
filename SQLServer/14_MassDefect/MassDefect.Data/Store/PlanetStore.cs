namespace MassDefect.Data.Store
{
    using Dto;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class PlanetStore
    {
        public static void AddPlanets(IEnumerable<PlanetDto> planetsCollection)
        {
            var context = new MassDefectContext();
            using (context)
            {
                foreach (var planet in planetsCollection)
                {
                    if (planet.Name == null || 
                        planet.Sun == null || 
                        planet.SolarSystem == null)
                    {
                        System.Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var solarSystem = SolarSystemStore.GetSolarSystem(
                            planet.SolarSystem, context);
                        var sun = StarStore.GetStar(planet.Sun, context);

                        if (solarSystem == null || sun == null)
                        {
                            System.Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            context.Planets.Add(new Planet
                            {
                                Name = planet.Name,
                                SolarSystem = solarSystem,
                                Sun = sun
                            });
                            System.Console.WriteLine(
                                $"Successfully imported Planet {planet.Name}.");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static Planet GetPlanet(string name, MassDefectContext context)
        {
            return context.Planets
                .FirstOrDefault(p => p.Name == name);
        }

        public static List<ExportPlanetDto> PlanetNoPeopleTeleported()
        {
            var context = new MassDefectContext();
            using (context)
            {
                return context.Planets
                    .Where(p =>
                        p.AnomaliesOrigin.All(a =>
                            a.Victims.Count == 0))
                    .Select(p => new ExportPlanetDto { Name = p.Name })
                    .ToList();
            }
        }
    }
}
