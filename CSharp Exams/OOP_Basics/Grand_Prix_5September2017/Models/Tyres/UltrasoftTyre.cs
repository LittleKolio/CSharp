using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) 
        : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    private double Grip { get; }

    public override double Degradation
    {
        get { return base.Degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new Exception("Blown Tyre");
            }
            base.Degradation = value;
        }
    }

    public override void DecreaseDegradation()
    {
        base.Degradation -= base.Hardness + this.Grip;
    }
}