using System.Collections.Generic;
using System.Linq;

public abstract class Nationbuilder
{
    public List<Bender> warriors;
    public List<Monument> monuments;
    public Nationbuilder()
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
        double bonus = this.monuments.Sum(mon => mon.Bonus());
        return power * (bonus / 100 + 1);
    }
}
