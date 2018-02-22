using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dough
{
    private const int caloriesPerGram = 2;
    private double weight;
    private double flourType;
    private double bakingTechnique;

    public double FlourType
    {
        get { return this.flourType; }
        private set
        {
            if (value < 0)
            {
                throw new Exception(
                    "Invalid type of dough.");
            }
            this.flourType = value;
        }
    }
    public double BakingTechnique
    {
        get { return this.bakingTechnique; }
        private set
        {
            if (value < 0)
            {
                throw new Exception(
                    "Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }

    public double Weight {
        get { return this.weight; }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new Exception(
                    "Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public double Calories
    {
        get
        {
            return caloriesPerGram * this.Weight *
                this.FlourType * this.bakingTechnique;
        }
    }

    public Dough(string flour, string baking, double weight)
    {
        this.FlourType = Modifiers.GetModifier(flour);
        this.BakingTechnique = Modifiers.GetModifier(baking);
        this.Weight = weight;
    }
}
