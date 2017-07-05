using System;
using System.Collections.Generic;

namespace Encapsulation_Exercises.Classes
{
    class Dough
    {
        private Dictionary<string, double> flourType
            = new Dictionary<string, double>()
            {
                { "white", 1.5 },
                { "wholegrain", 1.0 }
            };
        private Dictionary<string, double> bakingType 
            = new Dictionary<string, double>()
            {
                { "crispy", 0.9 },
                { "chewy", 1.1 },
                { "homemade", 1.0 }
            };

        private string flour;
        private string baking;
        private double weight;

        public Dough(string flour, string baking, double weight)
        {
            this.Flour = flour;
            this.Baking = baking;
            this.Weight = weight;
        }

        public string Flour
        {
            get { return this.flour; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    !this.flourType.ContainsKey(value))
                {
                    throw new ArgumentException(
                        "Invalid type of dough.");
                }
                this.flour = value;
            }
        }

        public string Baking
        {
            get { return this.baking; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    !this.bakingType.ContainsKey(value))
                {
                    throw new ArgumentException(
                        "Invalid type of dough.");
                }
                this.baking = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || 200 < value)
                {
                    throw new ArgumentException(
                        "Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double Calories()
        {
           return 2 * this.Weight * 
                this.flourType[this.Flour] *
                this.bakingType[this.Baking];
        }
    }
}
