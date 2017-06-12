namespace MassDefect.Data.Store
{
    using Dto;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StarStore
    {
        public static void AddStars(IEnumerable<StarDto> starsCollection)
        {
            var context = new MassDefectContext();
            using (context)
            {
                foreach (var star in starsCollection)
                {
                    if (star.Name == null || star.SolarSystem == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var solarSystem = SolarSystemStore.GetSolarSystem(
                            star.SolarSystem, context);

                        if (solarSystem == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            context.Stars.Add(new Star
                            {
                                Name = star.Name,
                                SolarSystem = solarSystem
                            });
                            Console.WriteLine(
                                $"Successfully imported Star {star.Name}.");
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        public static Star GetStar(string name, MassDefectContext context)
        {
            return context.Stars
                .FirstOrDefault(s => s.Name == name);
        }
    }
}
