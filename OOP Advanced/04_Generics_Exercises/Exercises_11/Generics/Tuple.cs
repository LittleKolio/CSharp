public class Tuple<T, U>
{
    private T item1;
    private U item2;

    public U Item2
    {
        get { return this.item2; }
        set { this.item2 = value; }
    }

    public T Item1
    {
        get { return this.item1; }
        set { this.item1 = value; }
    }

}