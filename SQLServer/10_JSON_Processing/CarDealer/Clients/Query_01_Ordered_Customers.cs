namespace CarDealer.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Newtonsoft.Json;
    using Models;
    using Newtonsoft.Json.Linq;

    public class Query_01_Ordered_Customers
    {
        static void Main()
        {
            using (var context = new CarDealerContext())
            {
                var empty = new List<Sale>();

                var customers = context.Customers
                    .OrderBy(c => c.BirthDate)
                    .ThenByDescending(c => c.IsYoungDriver)
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name,
                        BirthDate = c.BirthDate,
                        IsYoungDriver = c.IsYoungDriver,
                        Sales = empty
                    });


                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    //PreserveReferencesHandling = PreserveReferencesHandling.All,
                    Formatting = Formatting.Indented
                };
                var result = JsonConvert.SerializeObject(customers, settings);

                Console.WriteLine(result);
            }
        }
    }
}
