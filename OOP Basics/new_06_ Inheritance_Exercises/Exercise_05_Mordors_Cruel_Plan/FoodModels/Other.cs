using System;

public class Other : Food
{
    private const int modifier = -1;

    public override int Happiness
    {
        get { return modifier; }
    }
}