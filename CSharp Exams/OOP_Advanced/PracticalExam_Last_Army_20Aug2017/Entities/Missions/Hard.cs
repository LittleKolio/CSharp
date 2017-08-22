public class Hard : Mission
{
    private const double EnduranceRequired = 80;

    public Hard(string name, double scoreToComplete) 
        : base(name, EnduranceRequired, scoreToComplete)
    {
    }
}