using System.Collections.Generic;

public class AddCollection : CustomCollection, IAdd
{
    //adds an item to the END of the collection
    public int Add(string item)
    {
        base.collection.Add(item);
        return base.Used - 1;
    }
}