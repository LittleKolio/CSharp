namespace CarDealer.Data
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class CarDealerInitializer
        : DropCreateDatabaseAlways<CarDealerContext>
    {
        static Random rnd = new Random();

        protected override void Seed(CarDealerContext context)
        {
            ImportSuppliers(context);
            ImportParts(context);
            ImportCars(context);
            ImportCustomers(context);
            AddSales(context);
            base.Seed(context);
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            var suppliersXml = XDocument
                .Load(@"../../Import/suppliers.xml")
                .Root
                .Elements();

            //Xml Format
            //<supplier name="3M Company" is-importer="true" />

            var suppliersList = new List<Supplier>();
            foreach (var supplier in suppliersXml)
            {
                var tempSupplier = new Supplier
                {
                    Name = supplier.Attribute("name").Value,
                    isImporter = Boolean.Parse(supplier.Attribute("is-importer").Value)
                };
                suppliersList.Add(tempSupplier);
            }

            context.Suppliers.AddRange(suppliersList);
            context.SaveChanges();
        }

        private static void ImportParts(CarDealerContext context)
        {
            var partsXml = XDocument
                .Load(@"../../Import/parts.xml")
                .Root
                .Elements();

            //Xml Format
            //<part name="Bonnet/hood" price="1001.34" quantity="10" />

            var partsList = new List<Part>();
            var suppliersCount = context.Suppliers.Count();
            foreach (var part in partsXml)
            {
                var partTemp = new Part
                {
                    Name = part.Attribute("name").Value,
                    Price = decimal.Parse(part.Attribute("price").Value),
                    Quantity = int.Parse(part.Attribute("quantity").Value),
                    SupplierId = rnd.Next(1, suppliersCount + 1)
                };
                partsList.Add(partTemp);
            }

            context.Parts.AddRange(partsList);
            context.SaveChanges();
        }

        private static void ImportCars(CarDealerContext context)
        {
            var carsXml = XDocument
                .Load(@"../../Import/cars.xml")
                .Root
                .Elements();

            //Xml Format
            //<car>
            //    <make>Opel</make>
            //    <model>Astra</model>
            //    <travelled-distance>922337203685807</travelled-distance>
            //</car>

            var carsList = new List<Car>();
            foreach (var car in carsXml)
            {
                var carTemp = new Car
                {
                    Make = car.Element("make").Value,
                    Model = car.Element("model").Value,
                    TravelledDistance = long.Parse(car.Element("travelled-distance").Value),
                    Parts = AddPartsToCar(context)
                };
                carsList.Add(carTemp);
            }

            context.Cars.AddRange(carsList);
            context.SaveChanges();
        }

        private static List<Part> AddPartsToCar(CarDealerContext context)
        {
            var partsCount = context.Parts.Count();
            var partsList = new List<Part>();

            for (int i = 0; i < rnd.Next(10, 20 + 1); i++)
            {
                partsList.Add(
                    context.Parts.Find(rnd.Next(1, partsCount + 1))
                    );
            }
            return partsList;
        }

        private static void ImportCustomers(CarDealerContext context)
        {
            var customersXml = XDocument
                .Load(@"../../Import/customers.xml")
                .Root
                .Elements();

            //Xml Format
            //<customer name="Zada Attwood">
            //    <birth-date>1982-10-01T00:00:00</birth-date>
            //    <is-young-driver>true</is-young-driver>
            //</customer>

            var customersList = new List<Customer>();
            foreach (var customer in customersXml)
            {
                var customerTemp = new Customer
                {
                    Name = customer.Attribute("name").Value,
                    BirthDate = DateTime.Parse(customer.Element("birth-date").Value),
                    IsYoungDriver = bool.Parse(customer.Element("is-young-driver").Value)
                };
                customersList.Add(customerTemp);
            }

            context.Customers.AddRange(customersList);
            context.SaveChanges();
        }

        private static void AddSales(CarDealerContext context)
        {
            int[] discountArray = { 0, 5, 10, 15, 20, 30, 40, 50 };

            var salesList = new List<Sale>();
            var carsCount = context.Cars.Count();
            foreach (var customer in context.Customers)
            {
                for (int i = 0; i < rnd.Next(0, 10 + 1); i++)
                {
                    var saleTemp = new Sale
                    {
                        Customer = customer,
                        CarId = rnd.Next(1, carsCount + 1),
                        Discount = discountArray[rnd.Next(discountArray.Length)]
                    };
                    salesList.Add(saleTemp);
                }
            }
            context.Sales.AddRange(salesList);
            context.SaveChanges();
        }
    }
}
