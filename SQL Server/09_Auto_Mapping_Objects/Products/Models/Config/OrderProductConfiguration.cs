namespace Products.Models.Config
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OrderProductConfiguration : EntityTypeConfiguration<OrderProduct>
    {
        public OrderProductConfiguration()
        {
            this.HasKey(op => new { op.OrderId, op.ProductId });

            this.HasRequired(op => op.Product)
                .WithMany(p => p.OrdersProducts)
                .HasForeignKey(op => op.ProductId);

            this.HasRequired(op => op.Order)
                .WithMany(o => o.OrdersProducts)
                .HasForeignKey(op => op.OrderId);
        }
    }
}
