namespace MassDefect.Data.Store
{
    using Dto;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolarSystemStore
    {
        public static void AddSolarSystems(
            IEnumerable<SolarSystemDto> solarSystemCollection)
        {
            var context = new MassDefectContext();
            using (context)
            {
                foreach (var solarSystem in solarSystemCollection)
                {
                    if (solarSystem.Name == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        context.SolarSystems.Add(new SolarSystem
                        { Name = solarSystem.Name });
                        Console.WriteLine(
                            $"Successfully imported Solar System {solarSystem.Name}.");
                    }
                }
                context.SaveChanges();
            }
        }

        public static SolarSystem GetSolarSystem(string name, MassDefectContext context)
        {
            return context.SolarSystems
                .FirstOrDefault(s => s.Name == name);
        }
    }
}
