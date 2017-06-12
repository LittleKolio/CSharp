namespace CarDealer.Clients
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Query_03_Local_Suppliers
    {
        static void Main()
        {
            using (var context = new CarDealerContext())
            {
                var suppliers = context.Suppliers
                    .Where(s => s.isImporter == false)
                    .Select(s => new
                    {
                        Id = s.Id,
                        Name = s.Name,
                        PartsCount = s.Parts.Count
                    });

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    //PreserveReferencesHandling = PreserveReferencesHandling.All,
                    Formatting = Formatting.Indented
                };

                var result = JsonConvert.SerializeObject(suppliers, settings);

                Console.WriteLine(result);
            }
        }
    }
}
