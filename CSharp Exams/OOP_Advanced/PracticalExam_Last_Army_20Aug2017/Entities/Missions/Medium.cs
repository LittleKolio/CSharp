public class Medium : Mission
{
    private const double EnduranceRequired = 20;

    public Medium(string name, double scoreToComplete) 
        : base(name, EnduranceRequired, scoreToComplete)
    {
    }
}