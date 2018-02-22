using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Topping
{
    private const int caloriesPerGram = 2;
    private double weight;
    private double type;

    public double Type
    {
        get { return this.type; }
    }

    public double Weight
    {
        get { return this.weight; }
    }

    public double Calories
    {
        get { return caloriesPerGram * this.Weight * this.Type; }
    }

    public Topping(string type, double weight)
    {
        SetType(type);
        SetWeight(type, weight);
    }

    private void SetWeight(string type, double weight)
    {
        if (weight < 1 || weight > 50)
        {
            throw new Exception(
                $"{type} weight should be in the range [1..50].");
        }
        this.weight = weight;
    }

    private void SetType(string type)
    {
        double result = Modifiers.GetModifier(type);
        if (result < 0)
        {
            throw new Exception(
                $"Cannot place {type} on top of your pizza.");
        }
        this.type = result;
    }
}
