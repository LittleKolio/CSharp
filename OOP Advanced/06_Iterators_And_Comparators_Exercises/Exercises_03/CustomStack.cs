using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomStack<T> : IEnumerable<T>
{
    private readonly IList<T> list;
    public CustomStack()
    {
        this.list = new List<T>();
    }

    public int Last
    {
        get { return this.list.Count - 1; }
    }

    public void Pop()
    {
        if (!this.list.Any())
        {
            throw new InvalidOperationException(
                "No elements");
        }
        this.list.RemoveAt(this.Last);
    }

    public void Push(params T[] elements)
    {
        foreach (var element in elements)
        {
            this.list.Add(element);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Last; i >= 0; i--)
        {
            yield return this.list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}