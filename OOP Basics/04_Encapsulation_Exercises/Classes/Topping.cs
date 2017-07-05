namespace Encapsulation_Exercises.Classes
{
    using System;
    using System.Collections.Generic;

    class Topping
    {
        private Dictionary<string, double> types
            = new Dictionary<string, double>()
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 }
            };

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get { return this.type; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    !this.types.ContainsKey(value))
                {
                    throw new ArgumentException(
                        $"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || 50 < value)
                {
                    throw new ArgumentException(
                        $"{this.Type} weight should be in the range[1..50].");
                }
                this.weight = value;
            }
        }

        public double Calories()
        {
            return 2 * this.Weight *
                 this.types[this.Type];
        }
    }
}
