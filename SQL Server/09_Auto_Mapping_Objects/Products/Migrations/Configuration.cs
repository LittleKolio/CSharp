namespace Products.Migrations
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Products.Data.ProductsContext";
        }

        protected override void Seed(ProductsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Product product = new Product()
            {
                Name = "piza"
            };

            List<Client> list = new List<Client>()
            {
                new Client() { Name = "tartei", Address = "goo 34" },
                new Client() { Name = "star6el", Address = "buu 22" },
                new Client() { Name = "p4eli4ka" }
            };

            foreach (Client client in list)
            {
                context.Clients.AddOrUpdate(c => c.Name, client);
            }
            context.Products.AddOrUpdate(p => p.Name, product);

            //compare by two props
            //context.Products.AddOrUpdate(p => new { p.Name, product.Description }, product);

            context.SaveChanges();
        }
    }
}
