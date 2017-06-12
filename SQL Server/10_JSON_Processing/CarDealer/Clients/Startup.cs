namespace CarDealer.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using System.IO;
    using Newtonsoft.Json;
    using Models;

    class Startup
    {
        static Random rnd = new Random();
        static void Main()
        {
            //using (var context = new CarDealerContext())
            //{
            //    context.Database.Initialize(true);
            //    ImportSuppliers(context);
            //    ImportParts(context);
            //    ImportCars(context);
            //    ImportCustomers(context);
            //    AddSales(context);
            //}
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            var file = File.ReadAllText(@"../../Import/suppliers.json");
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(file);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }

        private static void ImportParts(CarDealerContext context)
        {
            var file = File.ReadAllText(@"../../Import/parts.json");
            var parts = JsonConvert.DeserializeObject<List<Part>>(file);

            var suppliersCount = context.Suppliers.Count();
            foreach (var part in parts)
            {
                part.SupplierId = rnd.Next(1, suppliersCount + 1);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        private static void ImportCars(CarDealerContext context)
        {
            var file = File.ReadAllText(@"../../Import/cars.json");
            var cars = JsonConvert.DeserializeObject<List<Car>>(file);

            var partsCount = context.Parts.Count();
            foreach (var car in cars)
            {
                for (int i = 0; i < rnd.Next(10, 20 + 1); i++)
                {
                    car.Parts.Add(
                        context.Parts.Find(rnd.Next(1, partsCount + 1))
                        );
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void ImportCustomers(CarDealerContext context)
        {
            var file = File.ReadAllText(@"../../Import/customers.json");
            var customers = JsonConvert.DeserializeObject<List<Customer>>(file);
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void AddSales(CarDealerContext context)
        {
            var carsCount = context.Cars.Count();
            foreach (var customer in context.Customers)
            {
                for (int i = 0; i < rnd.Next(0, 10 + 1); i++)
                {
                    var sale = new Sale
                    {
                        Customer = customer,
                        CarId = rnd.Next(1, carsCount + 1),
                        Discount = rnd.Next(50 + 1)
                    };
                    context.Sales.Add(sale);
                }
            }
            context.SaveChanges();
        }
    }
}
