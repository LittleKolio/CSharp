﻿using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node head;
    private Node tail;
    public int Count { get; private set; }

    public LinkedList()
    {
        this.head = null;
        this.tail = null;
        this.Count = 0;
    }

    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }



    public void AddFirst(T item)
    {
        Node newNode = new Node(item);

        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.Next = this.head;
            this.head = newNode;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node newNode = new Node(item);

        if (this.Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            this.tail.Next = newNode;
            this.tail = newNode;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T item = this.head.Value;

        if (this.Count == 1)
        {
            this.head = null;
            this.tail= null;
        }
        else
        {
            this.head = this.head.Next;
        }
        this.Count--;

        return item;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T result = this.tail.Value;

        if (this.Count == 1)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            Node item = this.head;
            while (item.Next != this.tail)
            {
                item = item.Next;
            }
            item.Next = null;
            this.tail = item;
        }
        this.Count--;

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node item = this.head;
        while (item != null)
        {
            yield return item.Value;
            item = item.Next;
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
