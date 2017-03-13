namespace Sales.Models
{
    using System.Collections.Generic;

    public class Customer
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public virtual ICollection<Sale> SalesForCustomer { get; set; }
        public Customer()
        {
            this.SalesForCustomer = new HashSet<Sale>();
        }
    }
}
