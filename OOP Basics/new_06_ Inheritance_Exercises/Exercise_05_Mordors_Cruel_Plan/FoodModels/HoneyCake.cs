public class Honeycake : Food
{
    private const int modifier = 5;

    public override int Happiness
    {
        get { return modifier; }
    }
}