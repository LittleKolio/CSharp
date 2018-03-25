using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : ICustomList<T>
    where T : IComparable
{
    private IList<T> list;

    public CustomList(IEnumerable<T> collection)
    {
        this.list = new List<T>(collection);
    }

    public CustomList() : this (Enumerable.Empty<T>())
    {
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }
    
    public bool Contains(T element)
    {
        return this.list.Contains(element);
    }

    public int CountGreaterThan(T element)
    {
        return this.list.Count(e => e.CompareTo(element) > 0);
    }

    public T Max()
    {
        return this.list.Max();
    }

    public T Min()
    {
        return this.list.Min();
    }

    public T Remove(int index)
    {
        T element = this.list[index];
        this.list.RemoveAt(index);
        return element;
    }

    public void Swap(int index1, int index2)
    {
        T element = this.list[index1];
        this.list[index1] = this.list[index2];
        this.list[index2] = element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}