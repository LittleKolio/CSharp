public class Easy : Mission
{
    private const double enduranceRequired = 20;
    private const double wearLevelDecrement = 30;
    private const string name = "Suppression of civil rebellion";

    public Easy(double scoreToComplete) 
        : base(scoreToComplete, enduranceRequired, wearLevelDecrement, name)
    {
    }
}