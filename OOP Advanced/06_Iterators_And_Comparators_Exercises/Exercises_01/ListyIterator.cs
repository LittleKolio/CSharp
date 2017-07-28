using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerator<T>
{
    private readonly IList<T> list;
    private int index;

    public ListyIterator()
    {
        this.Reset();
        this.list = new List<T>();
    }

    public T Current
    {
        get { return default(T); }
    }

    object IEnumerator.Current
    {
        get { return this.Current; }
    }

    public void Dispose() { }

    public bool MoveNext()
    {
        return ++this.index < this.list.Count;
    }

    public void Reset()
    {
        this.index = 
    }
}