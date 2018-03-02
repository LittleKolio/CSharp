using System.Collections.Generic;

public abstract class CustomCollection
{
    public List<string> collection;
    public int Used
    {
        get { return this.collection.Count; }
    }

    public CustomCollection()
    {
        this.collection = new List<string>();
    }
}