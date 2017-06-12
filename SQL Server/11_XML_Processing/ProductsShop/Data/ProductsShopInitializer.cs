namespace ProductsShop.Data
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class ProductsShopInitializer
        : DropCreateDatabaseAlways<ProductsShopContext>
    {
        static Random rnd = new Random();

        protected override void Seed(ProductsShopContext context)
        {
            ImportUsers(context);
            ImportCategories(context);
            ImportProducts(context);
            base.Seed(context);
        }

        private static void ImportUsers(ProductsShopContext context)
        {
            var usersXml = XDocument
                .Load(@"../../Import/users.xml")
                .Root
                .Elements();
            var usersList = new List<User>();
            foreach (var user in usersXml)
            {
                var tempUser = new User
                {
                    FirstName = user.Attribute("first-name")?.Value,
                    LastName = user.Attribute("last-name")?.Value,
                    Age = null
                };
                int age;
                if (int.TryParse(user.Attribute("age")?.Value, out age))
                {
                    tempUser.Age = age;
                }
                usersList.Add(tempUser);
            }
            context.Users.AddRange(usersList);
            context.SaveChanges();
        }

        private static void ImportCategories(ProductsShopContext context)
        {
            var categoriesXml = XDocument
                .Load(@"../../Import/categories.xml")
                .Root
                .Elements();
            var categoriesList = new List<Category>();
            foreach (var category in categoriesXml)
            {
                categoriesList.Add(new Category
                {
                    Name = category.Element("name").Value
                });
            }
            context.Categories.AddRange(categoriesList);
            context.SaveChanges();
        }

        private static void ImportProducts(ProductsShopContext context)
        {
            var productsXml = XDocument
                .Load(@"../../Import/products.xml")
                .Root
                .Elements();

            var productsList = new List<Product>();
            var usersCount = context.Users.Count();
            var categoriesCount = context.Categories.Count();

            for (int i = 0; i < productsXml.Count(); i++)
            {
                var elementName = productsXml.ElementAt(i)
                    .Element("name").Value;
                var elementAge = decimal.Parse(productsXml.ElementAt(i)
                   .Element("price").Value);

                var productTemp = new Product
                {
                    Name = elementName,
                    Price = elementAge,
                    SellerId = rnd.Next(1, usersCount + 1),
                    BuyerId = null
                };
                for (int r = 0; r < rnd.Next(1, 5); r++)
                {
                    var categoryTemp = context.Categories
                        .Find(rnd.Next(1, categoriesCount + 1));
                    productTemp.Categories.Add(categoryTemp);
                };
                if (i % 8 != 0)
                {
                    productTemp.BuyerId = rnd.Next(1, usersCount + 1);
                }
                productsList.Add(productTemp);
            }
            context.Products.AddRange(productsList);
            context.SaveChanges();
        }
    }
}
