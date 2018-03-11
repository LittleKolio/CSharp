using System;

public abstract class Tyre
{
    private const double startDegradation = 100;
    protected double minDegradation;

    public Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = startDegradation;
        this.minDegradation = 0;
    }

    public double Hardness { get; private set; }

    private double degradation;
    public double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < minDegradation)
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