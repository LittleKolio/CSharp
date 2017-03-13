namespace Sales.Clients
{
    using Models;
    using Data;
    using Clients;
    using System.Collections.Generic;
    using System;

    class Startup
    {
        static void Main()
        {
            var context = new SalesContext();
            context.Database.Initialize(true);

            //Data(context);
        }

        private static void Data(SalesContext context)
        {
            var p1 = new Product()
            {
                Name = "p1",
                Quantity = 23.23,
                Price = 79.44m
            };
            var p2 = new Product()
            {
                Name = "p2",
                Quantity = 2.03,
                Price = 967.44m
            };

            var c1 = new Customer()
            {
                //Name = "c1",
                Email = "sdf_iu@gdfgd.gu",
                CreditCardNumber = "PSDOFJP45QRQ3P4"
            };
            var c2 = new Customer()
            {
                //Name = "c2",
                Email = "iul_afwef@gdfgd.gu",
                CreditCardNumber = "FFFOU48UTAJ34TXU"
            };

            var storeA = new StoreLocation()
            { LocationName = "storeA" };
            var storeB = new StoreLocation()
            { LocationName = "storeB" };

            var sale1 = new Sale()
            {
                ProductId = 1,
                CustomerId = 1,
                StoreLocationId = 1,
                Date = new DateTime(2001, 1, 1)
            };
            var sale2 = new Sale()
            {
                ProductId = 1,
                CustomerId = 2,
                StoreLocationId = 1,
                Date = new DateTime(2002, 1, 1)
            };
            var sale3 = new Sale()
            {
                ProductId = 2,
                CustomerId = 2,
                StoreLocationId = 1,
                Date = new DateTime(2003, 1, 1)
            };
            var sale4 = new Sale()
            {
                ProductId = 2,
                CustomerId = 2,
                StoreLocationId = 2,
                Date = new DateTime(2004, 1, 1)
            };

            context.Products.AddRange(new List<Product>() { p1, p2 });
            context.SaveChanges();

            context.Customers.AddRange(new List<Customer>() { c1, c2 });
            context.SaveChanges();

            context.StoreLocations.AddRange(new List<StoreLocation>() { storeA, storeB });
            context.SaveChanges();

            context.Sales.AddRange(new List<Sale>() { sale1, sale2, sale3, sale4 });
            context.SaveChanges();
        }
    }
}
