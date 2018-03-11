public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) 
        : base(hardness)
    {
        base.minDegradation = 30;
        this.Grip = grip;
    }

    public double Grip { get; set; }

    public override void DecreaseDegradation()
    {
        base.Degradation -= (base.Hardness + this.Grip);
    }
}