using System;

public class AddCollection : CustomCollection, IAddCollection
{
    public int Add(string element)
    {
        base.List.Add(element);
        return base.List.Count - 1;
    }
}