namespace ProductsShop.Clients
{
    using ProductsShop.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.IO;
    using Newtonsoft.Json.Linq;
    using Models;

    class Starup
    {
        //static Random rnd = new Random();
        static void Main(string[] args)
        {
            //var context = new ProductsShopContext();
            //context.Database.Initialize(true);

            //using (var context = new ProductsShopContext())
            //{
            //    ImportUsers(context);
            //    ImportProducts(context);
            //    ImportCategories(context);
            //}
        }

        private static void ImportUsers(ProductsShopContext context)
        {
            var usersJson = File.ReadAllText(@"../../Import/users.json");
            var users = JsonConvert.DeserializeObject<List<User>>(usersJson);
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void ImportProducts(ProductsShopContext context)
        {
            var productsJson = File.ReadAllText(@"../../Import/products.json");
            var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);

            var num = 0;
            var usCount = context.Users.Count();
            foreach (var product in products)
            {
                product.SellerId = (num % usCount) + 1;
                if (num % 3 != 0)
                {
                    product.BuyerId = (num * 2 % usCount) + 1;
                }
                num++;
            }
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportCategories(ProductsShopContext context)
        {
            var categoriesJson = File.ReadAllText(@"../../Import/categories.json");
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

            var num = 0;
            var psCount = context.Products.Count();
            foreach (var cat in categories)
            {
                for (int i = 0; i < num % 3; i++)
                {
                    cat.Products.Add(
                        context.Products.Find(num % psCount + 1));
                }
                num++;
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
