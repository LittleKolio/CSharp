namespace Sales.Models
{
    using System.Collections.Generic;

    public class StoreLocation
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public virtual ICollection<Sale> SalesInStore { get; set; }
        public StoreLocation()
        {
            this.SalesInStore = new HashSet<Sale>();
        }
    }
}
