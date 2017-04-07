namespace MassDefect.Export
{
    using Data.Store;
    using Newtonsoft.Json;
    using System;
    using System.IO;

    class Startup
    {
        static void Main()
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
    }
}
