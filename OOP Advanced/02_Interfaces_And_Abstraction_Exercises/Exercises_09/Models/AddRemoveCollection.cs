using System;

public class AddRemoveCollection : CustomCollection, IAddRemoveCollection
{
    public int Add(string element)
    {
        base.List.Insert(0, element);
        return 0;
    }

    public string Remove()
    {
        string last = base.List[base.List.Count - 1];
        base.List.RemoveAt(base.List.Count - 1);
        return last;
    }
}