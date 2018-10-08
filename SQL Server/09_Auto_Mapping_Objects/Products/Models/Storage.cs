namespace Products.Models
{
    using System.Collections.Generic;

    public class Storage
    {
        public Storage()
        {
            this.ProductsStocks = new HashSet<ProductStock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<ProductStock> ProductsStocks { get; set; }
    }
}
