namespace PlanetHunters.Import
{
    using Newtonsoft.Json;
    using Models;
    using System.IO;
    using System.Collections.Generic;
    using Data;
    using Dto.Import;
    using System.Xml.Linq;
    using System;
    using System.Linq;

    public class Import
    {
        public static void ImportAstronomers()
        {
            var json = File.ReadAllText(
                @"../../../import/astronomers.json");
            var astronomers = JsonConvert
                .DeserializeObject<IEnumerable<AstronomerDto>>(json);
            Service.AddAstronomers(astronomers);
        }

        public static void ImportTelescopes()
        {
            var json = File.ReadAllText(
                @"../../../import/telescopes.json");
            var telescopes = JsonConvert
               .DeserializeObject<IEnumerable<TelescopeDto>>(json);
            Service.AddTelescopes(telescopes);
        }

        public static void ImportPlanets()
        {
            var json = File.ReadAllText(
                @"../../../import/planets.json");
            var planets = JsonConvert
               .DeserializeObject<IEnumerable<PlanetDto>>(json);
            Service.AddPlanets(planets);
        }

        public static void ImportStars()
        {
            var xml = XDocument.Load(
                @"../../../import/stars.xml");
            var starsElements = xml.Root.Elements();

            var starsList = new List<StarDto>();
            foreach (var star in starsElements)
            {
                starsList.Add(new StarDto
                {
                    Name = star.Element("Name").Value,
                    Temperature = int.Parse(star.Element("Temperature").Value),
                    StarSystem = star.Element("StarSystem").Value
                });
            }
            Service.AddStar(starsList);
        }

        public static void ImportDiscoveries()
        {
            var xml = XDocument.Load(
                @"../../../import/discoveries.xml");
            var discoveriesElements = xml.Root.Elements();

            var discoveriesList = new List<DiscoveryDto>();
            foreach (var discovery in discoveriesElements)
            {
                var starsElement = discovery.Element("Stars").Elements();
                var starsList = ConvertStarsElements(starsElement);

                discoveriesList.Add(new DiscoveryDto
                {
                    DateMade = DateTime.Parse(discovery.Attribute("DateMade").Value),
                    Telescope = discovery.Attribute("Telescope").Value,
                    Stars = starsList,
                    Planets = discovery.Element("Planets")
                        .Elements()
                        .Select(e => e.Value)
                        .ToList()

            });
            }

            Console.Read();
        }

        //private static List<string> ConverPlanetstElements(IEnumerable<XElement> planets)
        //{
        //    var planetslist = new List<string>();
        //    if (planets != null)
        //    {
        //        foreach (var element in planets)
        //        {
        //            //Console.WriteLine(element.Value);
        //            string planetArray = { };
        //            planetArray[0] = element.Value;
        //            string temperature = element.Attribute("Temperature")?.Value;
        //            if (temperature != null) { planetArray[1] = temperature; }
        //            planetslist.Add(planetArray);
        //        }
        //    }

        //    return planetslist;
        //}

        private static List<string[]> ConvertStarsElements(IEnumerable<XElement> starsElement)
        {
            var starsList = new List<string[]>();
            if (starsElement != null)
            {
                foreach (var element in starsElement)
                {
                    //Console.WriteLine(element.Attribute("Temperature")?.Value);
                    //Console.WriteLine(element.Value);
                    string[] starArray;
                    var starName = element.Value;
                    var temperature = element.Attribute("Temperature")?.Value;

                    if (temperature != null)
                    {
                        starArray = new string[] { starName, temperature};
                    }
                    else
                    {
                        starArray = new string[] { starName };
                    }
                    starsList.Add(starArray);
                }
            }

            return starsList;
        }
    }
}
