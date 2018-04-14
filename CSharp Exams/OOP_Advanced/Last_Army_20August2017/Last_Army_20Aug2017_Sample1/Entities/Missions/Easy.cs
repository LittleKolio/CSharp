public class Easy : Mission
{
    private const double enduranceRequired = 20;
    private const double wearLevelDecrement = 30;

    public Easy(double scoreToComplete) 
        : base(scoreToComplete, enduranceRequired, wearLevelDecrement)
    {
    }
}