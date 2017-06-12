namespace LocalStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string DistributorName { get; set; }

        [MaxLength]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Weight { get; set; }

        public int Quantity { get; set; }
    }
}
