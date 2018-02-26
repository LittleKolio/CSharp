public class Melon : Food
{
    private const int modifier = 1;

    public override int Happiness
    {
        get { return modifier; }
    }
}