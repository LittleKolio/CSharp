namespace Data
{
    using System.Data.Entity;
    using Models;
    using System.Collections.Generic;

    class InitializeAndSeed : DropCreateDatabaseAlways<LocalStoreContext>
    {
        protected override void Seed(LocalStoreContext context)
        {
            var handGrenade = new Product()
            {
                Name = "hand grenade",
                DistributorName = "gestapo(germany)",
                Description = "Stick grenades have a long handle attached to the grenade proper, providing leverage for longer throwing distance, at the cost of additional weight.",
                Price = 5.55m,
                Weight = 530.56m,
                Quantity = 7
            };

            var panzer4 = new Product()
            {
                Name = "panzer 4",
                DistributorName = "MAN, Daimler-Benz, Rheinmetall-Borsig, Krupp(germany)",
                Description = "The Panzer IV was the workhorse of the German tank force during World War II. It saw combat in all theaters, and was the only German tank to remain in production for the entire war.",
                Price = 66666.6m,
                Weight = 7.601m,
                Quantity = 2
            };

            var ak47 = new Product()
            {
                Name = "ak-47",
                DistributorName = "Izhevsk(russia)",
                Description = "The AK-47, or AK as it is officially known (also known as the Kalashnikov) is a selective-fire (semi-automatic and automatic), gas-operated 7.62×39 mm assault rifle, developed in the Soviet Union by Mikhail Kalashnikov. It is officially known in the Soviet documentation as Avtomat Kalashnikova.",
                Price = 123.18m,
                Weight = 142.561m,
                Quantity = 55
            };

            context.Products.AddRange(new List<Product> { handGrenade, tomato, ak47 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
