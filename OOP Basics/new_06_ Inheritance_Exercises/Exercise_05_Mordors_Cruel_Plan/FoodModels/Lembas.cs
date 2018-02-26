public class Lembas : Food
{
    private const int modifier = 3;

    public override int Happiness
    {
        get { return modifier; }
    }
}