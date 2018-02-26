public class Cram : Food
{
    private const int modifier = 2;
    public override int Happiness
    {
        get { return modifier; }
    }
}
