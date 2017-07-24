using System.Collections.Generic;

public abstract class CustomCollection
{
    private readonly IList<string> list;

    public CustomCollection()
    {
        this.list = new List<string>();
    }

    public IList<string> List
    {
        get { return this.list; }
    }
}