namespace ProductsShop.Models.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    public class ProductConfig
        : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            this.HasOptional(p => p.Buyer)
                .WithMany(u => u.ProductsBought)
                .HasForeignKey(p => p.BuyerId);

            //modelBuilder.Entity<User>()
            //  .HasMany(p => p.ProductsBought)
            //  .WithOptional(u => u.Buyer);

            this.HasRequired(p => p.Seller)
                .WithMany(u => u.ProductsSold)
                .HasForeignKey(p => p.SellerId);

            //modelBuilder.Entity<User>()
            //  .HasMany(p => p.ProductsSold)
            //  .WithRequired(u => u.Seller);
        }
    }
}
