namespace CarDealer.Clients
{
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Query_02_Cars_From_Make_Toyota
    {
        static void Main()
        {
            using (var context = new CarDealerContext())
            {
                var cars = context.Cars
                    .Where(c => c.Make == "Toyota")
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    //PreserveReferencesHandling = PreserveReferencesHandling.All,
                    Formatting = Formatting.Indented
                };

                var result = JsonConvert.SerializeObject(cars, settings);

                Console.WriteLine(result);
            }
        }
    }
}
