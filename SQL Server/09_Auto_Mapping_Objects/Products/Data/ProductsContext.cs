namespace Products.Data
{
    using Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsContext : DbContext
    {
        public ProductsContext()
            : base("name=ProductsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsContext, Configuration>());
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products{ get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}