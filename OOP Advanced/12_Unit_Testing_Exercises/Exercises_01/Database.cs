using System;
using System.Collections.Generic;
using System.Linq;

public class Database : IDatabase
{
    private int[] elements;
    private int index;
    private static int INITIAL_CAPACITY = 16;

    public Database()
    {
        this.elements = new int[INITIAL_CAPACITY];
        this.index = 0;
    }

    public Database(IEnumerable<int> elements)
        : this()
    {
        this.Elements = elements.ToArray();
        this.index = elements.Count();
    }

    private int[] Elements
    {
        get { return this.elements; }
        set
        {
            //Console.WriteLine("IN");
            if (value.Length < 1 || INITIAL_CAPACITY < value.Length)
            {
                throw new InvalidOperationException(
                    "The size of the array is over 16 long");
            }
            Array.Copy(value, this.elements, value.Length);

        }
    }

    public int Count
    {
        get { return this.index; }
    }

    public void Add(int element)
    {
        if (this.index >= INITIAL_CAPACITY)
        {
            throw new InvalidOperationException(
                "Database is 16 integers long");
        }
        this.elements[this.index] = element;
        this.index++;
    }

    public void Remove()
    {
        if (this.index == 0)
        {
            throw new InvalidOperationException(
                "Database is empty");
        }
        this.index--;
        this.elements[this.index] = default(int);
    }

    public int[] Fech()
    {
        int[] result = new int[this.index];
        Array.Copy(this.Elements, result, this.index);
        return result;
    }
}