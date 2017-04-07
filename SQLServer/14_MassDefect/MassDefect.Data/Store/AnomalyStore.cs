namespace MassDefect.Data.Store
{
    using Dto;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
