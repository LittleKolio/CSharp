namespace CarDealer.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    class Query_01_Cars
    {
        static void Main()
        {
            var context = new CarDealerContext();
            using (context)
            {
                var cars = context.Cars
                    .Where(c => c.TravelledDistance > 2e+6)
                    .OrderBy(c => c.Make)
                    .ThenBy(c => c.Model);
            }
        }
    }
}
