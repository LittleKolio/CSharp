namespace MassDefect.Export
{
    using Data.Dto;
    using Data.Store;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    class Startup
    {
        static void Main()
        {
            //NoPeopleTeleported();
            //NotBeenVictims();
            //AnomalyStore.AnomalyAffectedMostPeople();
            //AnomalyStore.ThirdGalaxySolarSystems();
            ThirdGalaxySolarSystems();
        }

        private static void ThirdGalaxySolarSystems()
        {
            var result = AnomalyStore.ThirdGalaxySolarSystems();
            var serializer = new XmlSerializer(typeof(List<anomaly>));
            var writer = new StreamWriter(
                "../../../export/anomaliesForThirdGalaxy_2.xml");
            using (writer)
            {
                serializer.Serialize(writer, result);
            }
        }

        private static void NoPeopleTeleported()
        {
            var palnets = PlanetStore.PlanetNoPeopleTeleported();
            var settings = new JsonSerializerSettings
            {
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                //PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented
            };

            var result = JsonConvert.SerializeObject(palnets, settings);
            File.WriteAllText(@"../../../export/plaets.json", result);
            Console.WriteLine(result);
        }

        private static void NotBeenVictims()
        {
            var notVictims = PersonStore.PeopleNotBeenVictims();
            var settings = new JsonSerializerSettings
            {
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                //PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented
            };

            var result = JsonConvert.SerializeObject(notVictims, settings);
            File.WriteAllText(@"../../../export/notVictims.json", result);
            Console.WriteLine(result);
        }
    }
}
