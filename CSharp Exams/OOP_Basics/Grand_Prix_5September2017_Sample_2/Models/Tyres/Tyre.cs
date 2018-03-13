using System;

public abstract class Tyre
{
    private const double startDegradation = 100;

    public Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = startDegradation;
    }

    public double Hardness { get; private set; }

    protected double degradation;
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