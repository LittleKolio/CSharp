using System;
using System.Collections;
using System.Collections.Generic;

public class CircularQueue<T> : IEnumerable<T>
{
    private T[] arr;
    private const int DefaultCapacity = 4;
    private int capacity;
    private int head;
    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.capacity = capacity;
        this.arr = new T[capacity];
        this.head = 0;
        this.Count = 0;
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.capacity)
        {
            this.Resize();
        }

        int index = (this.head + this.Count) % this.capacity;
        this.arr[index] = element;
        this.Count++;

    }

    private void Resize()
    {
        T[] newArray = new T[this.capacity * 2];
        this.capacity *= 2;
        this.CopyAllElements(newArray);
        this.arr = newArray;
        this.head = 0;
    }

    private void CopyAllElements(T[] newArray)
    {
        for (int i = 0; i < this.Count; i++)
        {
            int index = (i + this.head) % this.capacity;
            newArray[i] = this.arr[index];
        }
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.arr[this.head];

        if (this.Count == 1)
        {
            this.head = 0;
        }
        else
        {
            this.head = (this.head + 1) % this.capacity;
        }
        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        T[] newArray = new T[this.Count];
        this.CopyAllElements(newArray);
        return newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
