using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerator<T>
{
    private readonly IList<T> list;
    private int index;

    public ListyIterator()
    {
        this.list = new List<T>();
    }

    public T Current
    {
        get { return default(T); }
    }

    object IEnumerator.Current
    {
        get { }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}