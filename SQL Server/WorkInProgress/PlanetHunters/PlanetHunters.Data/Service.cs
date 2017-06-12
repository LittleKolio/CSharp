namespace PlanetHunters.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Dto.Import;
    using System.Data.Entity.Validation;

    public class Service
    {
        public static void PrintSuccess(string result)
        {
            Console.WriteLine(
                $"Record {result} successfully imported.");
        }

        public static void AddAstronomers(IEnumerable<AstronomerDto> astronomers)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                foreach (var astronomer in astronomers)
                {
                    if (astronomer.FirstName == null ||
                        astronomer.LastName == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        context.Astronomers.Add(new Astronomer
                        {
                             FirstName = astronomer.FirstName,
                             LastName = astronomer.LastName
                        });
                        PrintSuccess(astronomer.FirstName + " " + astronomer.LastName);
                    }
                }
                context.SaveChanges();
            }
        }

        public static void AddStarSystem(StarSystem starSystem)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                context.StarSystems.Add(starSystem);
                PrintSuccess(starSystem.Name);
                context.SaveChanges();
            }
        }

        public static Astronomer GetAstronomer(string fullname)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                return context.Astronomers
                    .FirstOrDefault(a => a.FullName == fullname);
            }
        }

        public static Planet GetPlanet(string name)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                return context.Planets
                    .FirstOrDefault(p => p.Name == name);
            }
        }

        public static Star GetStar(string name)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                return context.Stars
                    .FirstOrDefault(s => s.Name == name);
            }
        }

        public static StarSystem GetStarSystem(string name)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                return context.StarSystems
                    .FirstOrDefault(s => s.Name == name);
            }
        }

        public static void AddStar(List<StarDto> starsList)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                foreach (var star in starsList)
                {
                    if (star.Temperature <= 2400)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var starSystem = GetStarSystem(star.StarSystem);
                        if (starSystem == null)
                        {
                            starSystem = new StarSystem { Name = star.StarSystem };
                            AddStarSystem(starSystem);
                        }

                        context.Stars.Add(new Star
                        {
                            Name = star.Name,
                            Temperature = star.Temperature,
                            StarSystemId = starSystem.Id
                        });

                        PrintSuccess(star.Name);
                    }
                }
                context.SaveChanges();
            }
        }

        /*
        public static void AddDiscoveries(List<DiscoveryDto> discoveriesList)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                foreach (var discovery in discoveriesList)
                {
                    var invalidInput = false;

                    if (discovery.Panets.Count > 0 && !invalidInput)
                    {
                        foreach(var planet in discovery.Panets)
                        {
                            if (GetPlanet(planet) == null) { invalidInput = true; }
                        }
                    }

                    if (discovery.Stars.Count > 0 && !invalidInput)
                    {
                        foreach (var star in discovery.Stars)
                        {
                            if (GetStar(star) == null) { invalidInput = true; }
                        }
                    }

                    if (discovery.Observers.Count > 0 && !invalidInput)
                    {
                        foreach (var astronomer in discovery.Panets)
                        {
                            var format = astronomer
                                .Split(new char[] { ' ', ',' },
                                    StringSplitOptions.RemoveEmptyEntries)
                                .ToArray()
                                .Reverse();

                            if (GetAstronomer(string.Join(" ", format)) == null) { invalidInput = true; }
                        }
                    }

                    if (discovery.Pioneers.Count > 0 && !invalidInput)
                    {
                        foreach (var astronomer in discovery.Pioneers)
                        {
                            var format = astronomer
                                .Split(new char[] { ' ', ',' },
                                    StringSplitOptions.RemoveEmptyEntries)
                                .ToArray()
                                .Reverse();

                            if (GetAstronomer(string.Join(" ", format)) == null) { invalidInput = true; }
                        }
                    }

                    if (invalidInput)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        Console.WriteLine("AAAAAAA");
                    }


                }
            }
        }
        */

        public static void AddPlanets(IEnumerable<PlanetDto> planets)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                foreach (var planet in planets)
                {
                    if (planet.Name == null ||
                        planet.Mass == null ||
                        planet.Mass <= 0.0 ||
                        planet.StarSystem == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var starSystem = GetStarSystem(planet.StarSystem);
                        if (starSystem == null)
                        {
                            starSystem = new StarSystem { Name = planet.StarSystem };
                            AddStarSystem(starSystem);
                        }

                        context.Planets.Add(new Planet
                        {
                            Name = planet.Name,
                            Mass = planet.Mass,
                            StarSystemId = starSystem.Id
                        });
                        PrintSuccess(planet.Name);
                    }
                }
                context.SaveChanges();
            }
        }

        public static void AddTelescopes(IEnumerable<TelescopeDto> telescopes)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                foreach (var telescope in telescopes)
                {
                    if (telescope.Name == null ||
                        telescope.Location == null ||
                        telescope.MirrorDiameter <= 0.0 )
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        context.Telescopes.Add(new Telescope
                        {
                            Name = telescope.Name,
                            Location = telescope.Location,
                            MirrorDiameter = telescope.MirrorDiameter
                        });
                        PrintSuccess(telescope.Name);
                    }
                }
                context.SaveChanges();
            }
        }

        public static object GetPlanetsToExport(string telescope)
        {
            var context = new PlanetHuntersContext();
            using (context)
            {
                return context.Planets
                    .Where(p => p.Discovery.Telescope.Name == telescope);
            }


        }
    }
}
