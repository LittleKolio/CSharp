using System;

public class ArrayList<T>
{
    private T[] arr;
    private int capacity;
    private int size;

    public ArrayList(int capacity = 2)
    {
        this.arr = new T[capacity];
        this.capacity = capacity;
        this.size = 0;
    }

    public int Count
    {
        get { return this.size; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.capacity)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.arr[index];
        }

        set
        {
            if (index < 0 || index >= this.capacity)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.arr[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.size >= this.capacity)
        {
            this.Grow();
        }
        this[this.size] = item;
        this.size++;
    }

    private void Grow()
    {
        T[] newArr = new T[this.capacity * 2];
        this.capacity *= 2;

        Array.Copy(this.arr, newArr, this.size);
        this.arr = newArr;
    }

    public T RemoveAt(int index)
    {
        T item = this[index];
        this[index] = default(T);

        this.ShiftLeft(index);

        if (this.size <= this.capacity / 3 && 
            this.capacity > 2)
        {
            this.Shrink();
        }

        this.size--;
        return item;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.size - 1; i++)
        {
            this.arr[i] = this.arr[i + 1];
        }
        this[this.size - 1] = default(T);
    }

    private void Shrink()
    {
        T[] newArr = new T[this.capacity / 2];
        this.capacity /= 2;
        Array.Copy(this.arr, newArr, this.size);
        this.arr = newArr;
    }
}
