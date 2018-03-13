using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) 
        : base(hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; set; }

    public override double Degradation
    {
        get { return base.degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new Exception("Blown Tyre");
            }
            base.degradation = value;
        }
    }

    public override void DecreaseDegradation()
    {
        base.Degradation -= (base.Hardness + this.Grip);
    }
}