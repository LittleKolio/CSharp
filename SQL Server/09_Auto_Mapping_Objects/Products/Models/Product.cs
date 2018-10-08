namespace Products.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.ProductsStocks = new HashSet<ProductStock>();
            this.OrdersProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<ProductStock> ProductsStocks { get; set; }

        public virtual ICollection<OrderProduct> OrdersProducts { get; set; }
    }
}