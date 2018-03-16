using System;

public abstract class Tyre
{
    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.hardness = hardness;
        this.Degradation = 100;
    }

    protected double hardness;
    protected double degradation;

    public string Name { get; private set; }
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
        this.Degradation -= this.hardness;
    }
}