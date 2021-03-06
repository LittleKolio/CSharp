﻿namespace ProductsShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Users should have many products sold and many products bought
    /// Users should have many friends (i.e. users)
    /// </summary>
    public class User
    {
        private ICollection<Product> productsSold;
        private ICollection<Product> productsBought;
        private ICollection<User> friends;
        public User()
        {
            this.ProductsSold = new HashSet<Product>();
            this.ProductsBought = new HashSet<Product>();
            this.Friends = new HashSet<User>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required, MinLength(3)]
        public string LastName { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<Product> ProductsSold
        {
            get { return this.productsSold; }
            set { this.productsSold = value; }
        }

        public virtual ICollection<Product> ProductsBought
        {
            get { return this.productsBought; }
            set { this.productsBought = value; }
        }

        public virtual ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }

    }
}
