namespace Encapsulation_Exercises.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Pizza
    {
        private string name;
        private Dough dough;
        private Topping[] toppings;
        public Pizza(string name, int count)
        {
            this.Name = name;
            this.Toppings = count;
        }

        public int Toppings
        {
            set
            {
                if (10 < value)
                {
                    throw new ArgumentException(
                    "Number of toppings should be in range [0..10].");
                }
                this.toppings = new Topping[value];
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length > 15)
                {
                    throw new ArgumentException(
                        "Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }

        public double CalculateCalories()
        {
            double sum = this.dough.Calories();
            foreach (Topping top in this.toppings)
            {
                sum += top.Calories();
            }
            return sum;
        }


        public void AddToppings(Topping topping)
        {
            for (int i = 0; i < this.toppings.Length; i++)
            {
                if (this.toppings[i] == null)
                {
                    this.toppings[i] = topping;
                    break;
                }
            }
        }
    }
}
