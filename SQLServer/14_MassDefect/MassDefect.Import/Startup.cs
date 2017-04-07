namespace MassDefect.Import
{
    using Data.Dto;
    using Data.Store;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    class Startup
    {
        static void Main(string[] args)
        {
            //ImportSolarSystems();
            //ImportStars();
            //ImportPlanets();
            //ImportPeople();
            //ImportAnomalies();
            //ImportAnomalyVictims();
            ImportMoreAnomalies();
        }

        public static void ImportSolarSystems()
        {
            var solarSystemJson = File.ReadAllText(
                @"../../../datasets/solar-systems.json");
            var solarSystemCollection = JsonConvert
                .DeserializeObject<IEnumerable<SolarSystemDto>>(solarSystemJson);
            SolarSystemStore.AddSolarSystems(solarSystemCollection);
        }

        public static void ImportStars()
        {
            var starsJson = File.ReadAllText(
                @"../../../datasets/stars.json");
            var starsCollection = JsonConvert
                .DeserializeObject<IEnumerable<StarDto>>(starsJson);
            StarStore.AddStars(starsCollection);
        }

        public static void ImportPlanets()
        {
            var planetsJson = File.ReadAllText(
                @"../../../datasets/planets.json");
            var planetsCollection = JsonConvert
                .DeserializeObject<IEnumerable<PlanetDto>>(planetsJson);
            PlanetStore.AddPlanets(planetsCollection);
        }

        public static void ImportPeople()
        {
            var peopleJson = File.ReadAllText(
                @"../../../datasets/persons.json");
            var peopleCollection = JsonConvert
                .DeserializeObject<IEnumerable<PersonDto>>(peopleJson);
            PersonStore.AddPeople(peopleCollection);
        }

        public static void ImportAnomalies()
        {
            var anomaliesJson = File.ReadAllText(
                @"../../../datasets/anomalies.json");
            var anomaliesCollection = JsonConvert
                .DeserializeObject<IEnumerable<AnomalyDto>>(anomaliesJson);
            AnomalyStore.AddAnomalies(anomaliesCollection);
        }

        public static void ImportAnomalyVictims()
        {
            var anomalyVictimsJson = File.ReadAllText(
                @"../../../datasets/anomaly-victims.json");
            var anomalyVictimsCollection = JsonConvert
                .DeserializeObject<IEnumerable<AnomalyVictimDto>>(anomalyVictimsJson);
            AnomalyStore.AddVictims(anomalyVictimsCollection);
        }

        public static void ImportMoreAnomalies()
        {
            var anomaliesXml = XDocument.Load(
                @"../../../datasets/new-anomalies.xml")
                .Root
                .Elements();

            var anomaliesListVictims = new List<AnomalyListVictimsDto>();
            foreach (var anomalyXml in anomaliesXml)
            {
                anomaliesListVictims.Add(new AnomalyListVictimsDto
                {
                    OriginPlanet = anomalyXml.Attribute("origin-planet").Value,
                    TeleportPlanet = anomalyXml.Attribute("teleport-planet")?.Value,
                    Victims = anomalyXml
                        .Element("victims")
                        .Elements()
                        .Select(e => e.Attribute("name")?.Value)
                        .ToList()
                });
            }
            AnomalyStore.AddAnomaliesListsVictims(anomaliesListVictims);
        }
    }
}
