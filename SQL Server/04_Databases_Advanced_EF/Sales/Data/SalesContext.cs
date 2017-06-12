namespace Sales.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
            Database.SetInitializer(
            //new DropCreateDatabaseIfModelChanges<SalesContext>()
            //new InitializeAndSeed()
            //new DropCreateDatabaseAlways<SalesContext>()
            new MigrateDatabaseToLatestVersion<SalesContext, Configuration>()
            );
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(8, 2);
        }
    }
}