using System.Collections.Generic;
using System.Linq;

public abstract class Nation
{
    public List<Bender> warriors;
    public List<Monument> monuments;
    public Nation()
    {
        this.warriors = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender(Bender bender)
    {
        this.warriors.Add(bender);
    }
    public double TotalPower()
    {
        double power = warriors.Sum(bender => bender.TotalPower());
        if (this.monuments.Count > 0)
        {
            power *= this.monuments.Sum(mon => mon.Bonus) / 100 + 1;
        }
        return power;
    }
}
