using System.Collections.Generic;

public class AddRemoveCollection : CustomCollection, IAddRemove
{
    //adds an item to the START of the collection
    public int Add(string item)
    {
        base.collection.Insert(0, item);
        return 0;
    }

    //removes the LAST item in the collection
    public string Remove()
    {
        int index = base.Used - 1;
        string item = base.collection[index];
        base.collection.RemoveAt(index);
        return item;
    }
}