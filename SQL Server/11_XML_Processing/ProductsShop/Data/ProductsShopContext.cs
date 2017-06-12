namespace ProductsShop.Data
{
    using Models;
    using Models.Configuration;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsShopContext : DbContext
    {

        public ProductsShopContext()
            : base("name=ProductsShopContext")
        {
            Database.SetInitializer(
                //new DropCreateDatabaseAlways<ProductsShopContext>()
                new ProductsShopInitializer()
                );
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}