public class Medium : Mission
{
    private const double EnduranceRequired = 50;

    public Medium(string name, double scoreToComplete) 
        : base(name, EnduranceRequired, scoreToComplete)
    {
    }
}