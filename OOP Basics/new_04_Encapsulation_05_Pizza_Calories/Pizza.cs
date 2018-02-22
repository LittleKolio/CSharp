using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new Exception(
                    "Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }
    public Dough Dough
    {
        get { return this.dough; }
    }

    public double TotalCalories
    {
        get { return this.Dough.Calories + this.toppings.Sum(t => t.Calories); }
    }

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }

    public void SetDough(Dough dough)
    {
        this.dough = dough;
    }

    public void AddTopplings(Topping topping)
    {
        if (this.toppings.Count == 10)
        {
            throw new Exception(
                "Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.TotalCalories:F2} Calories.";
    }
}
