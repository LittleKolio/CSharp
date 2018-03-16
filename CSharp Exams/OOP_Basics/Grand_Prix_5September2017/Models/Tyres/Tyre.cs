using System;

public abstract class Tyre
{
    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    private double degradation;

    public double Hardness { get; }
    public string Name { get; }
    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new Exception("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public virtual void DecreaseDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}