public class Medium : Mission
{
    private const double enduranceRequired = 50;
    private const double wearLevelDecrement = 50;

    public Medium(double scoreToComplete) 
        : base(scoreToComplete, enduranceRequired, wearLevelDecrement)
    {
    }
}