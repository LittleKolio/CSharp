namespace ProductsShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Categories should have many products
    /// </summary>
    public class Category
    {
        private ICollection<Product> products;
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        [MinLength(3), MaxLength(15)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
