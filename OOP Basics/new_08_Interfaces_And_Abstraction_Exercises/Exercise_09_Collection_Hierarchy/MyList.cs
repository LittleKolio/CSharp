using System.Collections.Generic;

public class MyList : CustomCollection, IAddRemove
{
    //adds an item to the START of the collection
    public int Add(string item)
    {
        base.collection.Insert(0, item);
        return 0;
    }

    //removes the FIRST element in the collection
    public string Remove()
    {
        string item = base.collection[0];
        base.collection.RemoveAt(0);
        return item;
    }
}