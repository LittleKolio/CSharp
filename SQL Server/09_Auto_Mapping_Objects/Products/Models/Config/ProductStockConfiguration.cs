namespace Products.Models.Config
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductStockConfiguration : EntityTypeConfiguration<ProductStock>
    {
        public ProductStockConfiguration()
        {
            this.HasKey(ps => new { ps.ProductId, ps.StorageId });

            this.HasRequired(ps => ps.Product)
                .WithMany(p => p.ProductsStocks)
                .HasForeignKey(ps => ps.ProductId);

            this.HasRequired(ps => ps.Storage)
                .WithMany(s => s.ProductsStocks)
                .HasForeignKey(ps => ps.StorageId);
        }
    }
}
