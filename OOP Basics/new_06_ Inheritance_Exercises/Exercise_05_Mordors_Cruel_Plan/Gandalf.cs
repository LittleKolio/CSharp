using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Gandalf
{
    private List<Food> eating;
    public int Happiness
    {
        get { return this.eating.Sum(f => f.Happiness); }
    }
    public Gandalf()
    {
        this.eating = new List<Food>();
    }

    public void AddFood(Food food)
    {
        this.eating.Add(food);
    }

    public string Mood()
    {
        if (this.Happiness < -5)
        {
            return "Angry";
        }
        else if (this.Happiness >= -5 && this.Happiness <= 0)
        {
            return "Sad";
        }
        else if (this.Happiness >= 1 && this.Happiness <= 15)
        {
            return "Happy";
        }
        else
        {
            return "JavaScript";
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.Happiness.ToString())
            .AppendLine(this.Mood());
        return sb.ToString().TrimEnd();
    }
}