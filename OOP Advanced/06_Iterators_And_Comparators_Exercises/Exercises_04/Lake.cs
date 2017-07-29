using System;
using System.Collections;
using System.Collections.Generic;

public class Lake<T> : IEnumerable<T>
{
    private readonly List<T> stones;
    public Lake(params T[] stones)
    {
        this.stones = new List<T>(stones);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Count; i += 2)
        {
            yield return this.stones[i];
        }

        int last = (this.stones.Count - 1) % 2 == 0
            ? this.stones.Count - 2
            : this.stones.Count - 1;

        for (int i = last; i > 0; i -= 2)
        {
            yield return this.stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}