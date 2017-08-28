public class Easy : Mission
{
    private const double EasyEnduranceRequired = 20;

    public Easy(string name, double scoreToComplete
        ) : base(name, scoreToComplete)
    {
    }

    public override double EnduranceRequired
    {
        get { return EasyEnduranceRequired; }
    }
}