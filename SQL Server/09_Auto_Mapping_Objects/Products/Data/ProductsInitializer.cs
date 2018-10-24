namespace Products.Data
{
    using Newtonsoft.Json;
    using Products.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductsInitializer : DropCreateDatabaseAlways<ProductsContext>
    {
        protected override void Seed(ProductsContext context)
        {
            AddEntities(context);

            AddConectionBetweenEntitiesInDB(context);

            base.Seed(context);
        }

        private void AddEntities(ProductsContext context)
        {
            string clientsJSON = File.ReadAllText(@"..\..\Import\Clients.json");
            string productsJSON = File.ReadAllText(@"..\..\Import\Products.json");
            string storagesJSON = File.ReadAllText(@"..\..\Import\Storages.json");

            context.Clients.AddRange(
                JsonConvert.DeserializeObject<IEnumerable<Client>>(clientsJSON));
            context.Products.AddRange(
                JsonConvert.DeserializeObject<IEnumerable<Product>>(productsJSON));
            context.Storages.AddRange(
                JsonConvert.DeserializeObject<IEnumerable<Storage>>(storagesJSON));

            context.SaveChanges();
        }

        private void AddConectionBetweenEntitiesInDB(ProductsContext context)
        {
            Storage storage = context.Storages.FirstOrDefault(s => s.Name == "Storage1");
            Product product = context.Products.FirstOrDefault(p => p.Name == "HP LaserJet Pro MFP M426fdw");

            ProductStock productStock = new ProductStock
            {
                Product = product,
                Storage = storage,
                Quantity = 3
            };

            context.ProductsStocks.Add(productStock);
            storage.ProductsStocks.Add(productStock);
            product.ProductsStocks.Add(productStock);

            context.SaveChanges();
        }
    }
}
