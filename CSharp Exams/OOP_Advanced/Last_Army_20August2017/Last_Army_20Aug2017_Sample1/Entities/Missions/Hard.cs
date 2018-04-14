public class Hard : Mission
{
    private const double enduranceRequired = 80;
    private const double wearLevelDecrement = 70;

    public Hard(double scoreToComplete) 
        : base(scoreToComplete, enduranceRequired, wearLevelDecrement)
    {
    }
}