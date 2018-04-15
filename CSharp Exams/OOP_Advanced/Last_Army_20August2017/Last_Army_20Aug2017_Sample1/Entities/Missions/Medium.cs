public class Medium : Mission
{
    private const double enduranceRequired = 50;
    private const double wearLevelDecrement = 50;
    private const string name = "Capturing dangerous criminals";

    public Medium(double scoreToComplete) 
        : base(scoreToComplete, enduranceRequired, wearLevelDecrement, name)
    {
    }
}