using System;
using System.Collections.Generic;

public abstract class Animal
{
    protected string sound;
    protected List<string> foodList;
    protected double weightModifier;

    private int foodEaten;
    private string name;
    private double weight;

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Sound
    {
        get { return this.sound; }
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public double Weight
    {
        get { return this.weight + this.FoodEaten * this.weightModifier; }
        set { this.weight = value; }
    }
    public int FoodEaten
    {
        get { return this.foodEaten; }
        set { this.foodEaten = value; }
    }

    public void EatFood(string food, int quantity)
    {
        if (this.foodList.Contains(food))
        {
            this.FoodEaten += quantity;
        }
        else
        {
            throw new ArgumentException(
                $"{this.GetType().Name} does not eat {food}!");
        }
    }
}