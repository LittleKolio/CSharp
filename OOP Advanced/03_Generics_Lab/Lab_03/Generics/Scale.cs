using System;

public class Scale<T>
    where T : IComparable<T>
{
    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    private T left;
    private T right;

    public T GetHavier()
    {
        int result = this.left.CompareTo(this.right);
        if (result > 0)
        {
            return this.left;
        }
        else if (result < 0)
        {
            return this.right;
        }
        return default(T);
    }
}