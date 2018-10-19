namespace Products.Data
{
    //using Migrations;
    using Models;
    using Models.Config;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsContext : DbContext
    {
        public ProductsContext()
            : base("name=ProductsContext")
        {
            Database.SetInitializer(
                //new MigrateDatabaseToLatestVersion<ProductsContext, Configuration>()
                //new DropCreateDatabaseAlways<ProductsContext>()
                new ProductsInitializer()
            );


        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products{ get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<OrderProduct> OrdersProducts { get; set; }
        public virtual DbSet<ProductStock> ProductsStocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new OrderProductConfiguration());
            modelBuilder.Configurations.Add(new ProductStockConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
        }
    }
}