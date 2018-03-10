public class Ultrasoft : Tyre
{
    public Ultrasoft(double hardness, double grip) 
        : base(hardness)
    {
        base.minDegradation = 30;
    }

    public double Grip { get; set; }

    public override void ReduceDegradation()
    {
        base.Degradation -= (this.Hardness + this.Grip);
    }
}