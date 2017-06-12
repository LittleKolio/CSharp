namespace MassDefect.Data.Store
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Dto;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class AnomalyStore
    {
        public static void AddAnomalies(
            IEnumerable<AnomalyDto> anomaliesCollection)
        {
            var context = new MassDefectContext();
            using (context)
            {
                foreach (var anomaly in anomaliesCollection)
                {
                    if (anomaly.OriginPlanet == null ||
                        anomaly.TeleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var originPlanet = PlanetStore.GetPlanet(
                            anomaly.OriginPlanet, context);
                        var teleportPlanet = PlanetStore.GetPlanet(
                            anomaly.TeleportPlanet, context);

                        if (originPlanet == null ||
                            teleportPlanet == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            context.Anomalies.Add(new Anomaly
                            {
                                OriginPlanet = originPlanet,
                                TeleportPlanet = teleportPlanet
                            });
                            Console.WriteLine($"Successfully imported Anomaly.");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static List<anomaly> ThirdGalaxySolarSystems()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Anomaly, anomaly>()
                   
                    .ForMember(
                    dto => dto.OriginPlanet,
                    opt => opt.MapFrom(src => src.OriginPlanet.Name))

                    .ForMember(
                    dto => dto.TeleportPlanet,
                    opt => opt.MapFrom(src => src.TeleportPlanet.Name));

                cfg.CreateMap<Person, victim>();
            });

            var context = new MassDefectContext();
            using (context)
            {
                return context.Anomalies
                    .ProjectTo<anomaly>()
                    .ToList();
            }
            /*
            var anomaliesXml = new XDocument();
            anomaliesXml.Add(new XElement("anomalies"));

            var context = new MassDefectContext();
            using (context)
            {
                var anomalies = context.Anomalies
                    .Select(a => new
                    {
                        id = a.Id,
                        originPlanetName = a.OriginPlanet.Name,
                        teleportPlanetName = a.TeleportPlanet.Name,
                        victims = a.Victims
                            .OrderBy(v => v.Id)
                            .Select(v => v.Name)
                            .ToList()
                    });

                foreach (var anomaly in anomalies)
                {
                    var anomalyElement = new XElement("anomaly",
                        new XAttribute("id", anomaly.id),
                        new XAttribute("origin-planet", anomaly.originPlanetName),
                        new XAttribute("teleport-planet", anomaly.teleportPlanetName));

                    var victimsElement = new XElement("victims");
                    foreach (var victim in anomaly.victims)
                    {
                        victimsElement.Add(
                            new XElement("victim", 
                                new XAttribute("name", victim)));
                    }
                    anomalyElement.Add(victimsElement);
                    anomaliesXml.Root.Add(anomalyElement);
                }
            }

            anomaliesXml.Save("../../../export/anomaliesForThirdGalaxy.xml");
            */
        }

        public static void AnomalyAffectedMostPeople()
        {
            var settings = new JsonSerializerSettings
            {
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                //PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented
            };

            var context = new MassDefectContext();
            using (context)
            {
                var anomaly = context.Anomalies
                    .OrderByDescending(a => a.Victims.Count)
                    .Select(a => new
                    {
                        id = a.Id,
                        originPlanet = new { name = a.OriginPlanet.Name },
                        teleportPlanet = new { name = a.TeleportPlanet.Name },
                        victimsCount = a.Victims.Count
                    })
                    .FirstOrDefault();

                var result = JsonConvert.SerializeObject(anomaly, settings);
                File.WriteAllText(@"../../../export/mostPeople.json", result);
                Console.WriteLine(result);
            }
        }

        public static Anomaly GetAnomaly(int id, MassDefectContext context)
        {
            return context.Anomalies.Find(id);
        }

        public static void AddVictims(
            IEnumerable<AnomalyVictimDto> anomalyVictimsCollection)
        {
            var context = new MassDefectContext();
            using (context)
            {
                foreach (var anomalyVictim in anomalyVictimsCollection)
                {
                    if (anomalyVictim.Person == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var victim = PersonStore.GetPerson(
                            anomalyVictim.Person, context);
                        var anomaly = GetAnomaly(anomalyVictim.Id, context);

                        if (victim == null || anomaly == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            anomaly.Victims.Add(victim);
                            Console.WriteLine(
                                $"Successfully {anomalyVictim.Person} to victims.");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static void AddAnomaliesListsVictims(
            List<AnomalyListVictimsDto> anomaliesListVictims)
        {
            var context = new MassDefectContext();
            using (context)
            {
                foreach (var alv in anomaliesListVictims)
                {
                    var originPlanet = PlanetStore.GetPlanet(alv.OriginPlanet, context);
                    var teleportPlanet = PlanetStore.GetPlanet(alv.TeleportPlanet, context);

                    if (originPlanet == null ||
                        teleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var anomaly = new Anomaly
                        {
                            OriginPlanet = originPlanet,
                            TeleportPlanet = teleportPlanet
                        };

                        foreach (var person in alv.Victims)
                        {
                            var victim = PersonStore.GetPerson(person, context);
                            if (victim != null)
                            {
                                anomaly.Victims.Add(victim);
                            }
                        }

                        context.Anomalies.Add(anomaly);
                        Console.WriteLine(
                            $"Successfully imported Anomaly with victims.");
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
