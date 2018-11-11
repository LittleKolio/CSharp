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
        private const int NUMBER = 20;
        private Random rnd;

        public ProductsInitializer()
        {
            this.rnd = new Random();
        }

        protected override void Seed(ProductsContext context)
        {
            AddEntities(context);

            AddConectionProductStock(context);
            AddConectionOrderProduct(context);

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

        private void AddConectionProductStock(ProductsContext context)
        {
            Product p;
            Storage s;
            int q;
            ProductStock isNewProductStock;

            List<ProductStock> productStocks = new List<ProductStock>();
            int iterations = rnd.Next(NUMBER);

            List<Storage> storages = context.Storages.ToList();
            List<Product> products = context.Products.ToList();


            for (int i = 0; i < iterations; i++)
            {
                p = products.ElementAt(this.rnd.Next(NUMBER) % products.Count);
                s = storages.ElementAt(this.rnd.Next(NUMBER) % storages.Count);
                q = rnd.Next(NUMBER);

                isNewProductStock = productStocks
                    .FirstOrDefault(ps => 
                        ps.Product.Name == p.Name && 
                        ps.Storage.Name == s.Name);

                if (isNewProductStock == null)
                {
                    isNewProductStock = new ProductStock
                    {
                        Product = p,
                        Storage = s
                    };

                    productStocks.Add(isNewProductStock);
                }

                isNewProductStock.Quantity += q;
            }

            context.ProductsStocks.AddRange(productStocks);
            context.SaveChanges();
        }

        private void AddConectionOrderProduct(ProductsContext context)
        {
            //Product p;
            //int q;
            //Order isNewOrder;
            //Client c;

            //List<Client> clients = context.Clients.ToList();

            List<Order> orders = new List<Order>();
            int iterations = rnd.Next(NUMBER);

            for (int i = 0; i < iterations; i++)
            {
                orders.Add(new Order());
            }
            context.Orders.AddRange(orders);

            //List<Product> products = context
            //    .ProductsStocks
            //    .Select(ps => ps.Product)
            //    .ToList();

            //for (int i = 0; i < iterations; i++)
            //{
            //    p = products.ElementAt(this.rnd.Next(NUMBER) % products.Count);
            //    q = rnd.Next(NUMBER);

            //    isNewOrder = orders
            //        .FirstOrDefault(o => 
            //            o.OrdersProducts.Count() == q &&
            //            o.OrdersProducts.Select(op => op.Product).
            //        );

            //    if (isNewProductStock == null)
            //    {
            //        isNewProductStock = new ProductStock
            //        {
            //            Product = p,
            //            Storage = s
            //        };

            //        productStocks.Add(isNewProductStock);
            //    }

            //    isNewProductStock.Quantity += q;
            //}

            //context.Orders.AddRange(orders);
            //context.SaveChanges();
        }
    }
}
