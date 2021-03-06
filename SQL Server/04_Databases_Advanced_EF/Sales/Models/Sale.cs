﻿namespace Sales.Models
{
    using System;

    public class Sale
    {
        //public Sale(int productId, int customerId, int storeLocationId, DateTime date)
        //{
        //    this.ProductId = productId;
        //    this.CustomerId = customerId;
        //    this.StoreLocationId = storeLocationId;
        //    this.Date = date;
        //}

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StoreLocationId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual StoreLocation StoreLocation { get; set; }
    }
}
