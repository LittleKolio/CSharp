namespace Encapsulation_Exercises.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public IReadOnlyList<Product> Bag
        {
            get { return this.bag; }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void BuyingProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                throw new ArgumentException(
                    $"{this.Name} can't afford {product.Name}");
            }
            this.bag.Add(product);
            this.money -= product.Cost;
        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {
                return $"{this.Name} - " + 
                    string.Join(", ", bag.Select(p => p.Name));
            }
        }
    }
}
