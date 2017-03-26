namespace CarDealer.Models
{

    /// <summary>
    /// Each sale has one customer and a customer can buy many cars
    /// In one sale, only one car can be sold
    /// </summary>
    public class Sale
    {
        public int Id { get; set; }
        public int Discount { get; set; } // percentage

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
