namespace Products.Models
{
    public class ProductStock
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
