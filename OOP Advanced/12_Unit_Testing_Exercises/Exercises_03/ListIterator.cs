﻿using System;
using System.Collections;
using System.Collections.Generic;

public class ListIterator<T> : IEnumerable<T>
{
    private readonly IList<T> list;
    private int index;

    public ListIterator(IEnumerable<T> elements)
    {
        this.Reset();
        this.list = new List<T>(elements);
    }

    public T Current
    {
        get { return this.list[this.index]; }
    }

    public bool Move()
    {
        bool result = HasNext();
        if (result) { this.index++; }
        return result;
    }

    public bool HasNext()
    {
        return (this.index + 1) < this.list.Count;
    }

    public void Reset()
    {
        this.index = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            yield return this.list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}