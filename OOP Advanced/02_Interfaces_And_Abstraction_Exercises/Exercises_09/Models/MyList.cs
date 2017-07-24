using System;

public class MyList : CustomCollection, IMyList
{
    public int Used
    {
        get { return base.List.Count; }
    }

    public int Add(string element)
    {
        base.List.Insert(0, element);
        return 0;
    }

    public string Remove()
    {
        string first = base.List[0];
        base.List.RemoveAt(0);
        return first;
    }
}