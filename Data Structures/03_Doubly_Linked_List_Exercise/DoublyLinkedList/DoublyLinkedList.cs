using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode
    {
        public ListNode(T value)
        {
            this.Value = value;
            this.PrevNode = null;
            this.NextNode = null;
        }

        public T Value { get; private set; }
        public ListNode NextNode { get; set; }
        public ListNode PrevNode { get; set; }
    }

    private ListNode head;
    private ListNode tail;
    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        ListNode node = new ListNode(element);
        if (this.head == null)
        {
            this.head = this.tail = node;
        }
        else
        {
            this.head.PrevNode = node;
            node.NextNode = this.head;
            this.head = node;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        ListNode node = new ListNode(element);
        if (this.tail == null)
        {
            this.head = this.tail = node;
        }
        else
        {
            this.tail.NextNode = node;
            node.PrevNode = this.tail;
            this.tail = node;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.head.Value;

        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            ListNode node = this.head.NextNode;
            this.head.NextNode = null;
            node.PrevNode = null;
            this.head = node;
        }
        this.Count--;

        return element;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.tail.Value;

        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            ListNode node = this.tail.PrevNode;
            this.tail.PrevNode = null;
            node.NextNode = null;
            this.tail = node;
        }
        this.Count--;

        return element;
    }

    public void ForEach(Action<T> action)
    {
        ListNode node = this.head;
        while (node != null)
        {
            action(node.Value);
            node = node.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode node = this.head;
        while (node != null)
        {
            yield return node.Value;
            node = node.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] arr = new T[this.Count];
        ListNode node = this.head;
        int i = 0;
        while (node != null)
        {
            arr[i] = node.Value;
            node = node.NextNode;
            i++;
        }

        return arr;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
