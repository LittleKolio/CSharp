namespace Products.Models
{
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            this.OrdersProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<OrderProduct> OrdersProducts { get; set; }
    }
}
