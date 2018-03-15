using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) 
        : base(hardness)
    {
        base.Name = "Ultrasoft";
        this.grip = grip;
    }

    private double grip;

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
        base.Degradation -= base.hardness + this.grip;
    }
}