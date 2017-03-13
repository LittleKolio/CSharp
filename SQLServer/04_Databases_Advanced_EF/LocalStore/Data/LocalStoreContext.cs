namespace LocalStore
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LocalStoreContext : DbContext
    {
        public LocalStoreContext()
            : base("name=LocalStoreContext")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<LocalStoreContext>()
                //new DropCreateDatabaseAlways<LocalStoreContext>()
                //new InitializeAndSeed();
                );
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.Weight)
                .HasPrecision(8, 3);
        }
    }
}