public class Mushrooms : Food
{
    private const int modifier = -10;

    public override int Happiness
    {
        get { return modifier; }
    }
}