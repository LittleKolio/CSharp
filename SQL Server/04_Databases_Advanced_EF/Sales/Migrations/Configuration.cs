namespace Sales.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SalesContext context)
        {
            /*
            //Product
            context.Products.Add(new Product()
            {
                Name = "p1",
                Quantity = 23.23,
                Price = 79.44m
            });
            context.Products.Add(new Product()
            {
                Name = "p2",
                Quantity = 2.03,
                Price = 967.44m
            });

            //Customer
            context.Customers.Add(new Customer()
            {
                FistName = "c1",
                LastName = "vzspmzweol",
                Email = "sdf_iu@gdfgd.gu",
                CreditCardNumber = "PSDOFJP45QRQ3P4"
            });
            context.Customers.Add(new Customer()
            {
                FistName = "c2",
                LastName = "weocowtkec",
                Email = "iul_afwef@gdfgd.gu",
                CreditCardNumber = "FFFOU48UTAJ34TXU"
            });

            //StoreLocations
            context.StoreLocations.Add(new StoreLocation()
            { LocationName = "storeA" });
            context.StoreLocations.Add(new StoreLocation()
            { LocationName = "storeB" });

            //Sales
            context.Sales.Add(new Sale()
            {
                ProductId = context.Products.Where(e => e.Name == "p1").FirstOrDefault().Id,
                CustomerId = context.Customers.Where(e => e.FistName == "c1").FirstOrDefault().Id,
                StoreLocationId = context.StoreLocations.Where(e => e.LocationName == "storeA").FirstOrDefault().Id
            });
            context.Sales.Add(new Sale()
            {
                ProductId = context.Products.Where(e => e.Name == "p1").FirstOrDefault().Id,
                CustomerId = context.Customers.Where(e => e.FistName == "c2").FirstOrDefault().Id,
                StoreLocationId = context.StoreLocations.Where(e => e.LocationName == "storeB").FirstOrDefault().Id
            });
            */
        }
    }
}
