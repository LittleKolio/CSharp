namespace PlanetHunters.Export
{
    using Newtonsoft.Json;
    using Data;
    using System;

    public class Export
    {
        public static void ExportPlanets(string telescope)
        {
            //var list = Service.GetPlanetsToExport(telescope);
            
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                //PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented
            };

            //var result = JsonConvert.SerializeObject(list, settings);

            Console.WriteLine(result);
        }
    }
}
