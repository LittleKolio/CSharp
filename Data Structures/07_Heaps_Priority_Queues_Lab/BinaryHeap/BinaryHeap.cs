using System;
using System.Collections.Generic;

public class BinaryHeap<T> 
    where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get { return this.heap.Count; }
    }

    public void Insert(T item)
    {
        this.heap.Add(item);
        //this.HeapifyUpRecursive(this.Count - 1);
        this.HeapifyUpIterative(this.Count - 1);
    }

    private void HeapifyUpIterative(int index)
    {
        int child = index;
        int parent = (child - 1) / 2;

        int compare = this.heap[parent].CompareTo(this.heap[child]);

        while (parent >= 0 && compare < 0)
        {
            this.Swap(parent, child);

            child = parent;
            parent = (child - 1) / 2;

            if (child == parent)
            {
                break;
            }

            compare = this.heap[parent].CompareTo(this.heap[child]);
        }
    }
    
    private void HeapifyUpRecursive(int child)
    {
        int parent = (child - 1) / 2;

        if (parent < 0)
        {
            return;
        }

        int compare = this.heap[parent].CompareTo(this.heap[child]);
        if (compare < 0)
        {
            this.Swap(parent, child);
            HeapifyUpRecursive(parent);
        }
    }

    private void Swap(int parent, int child)
    {
        T temp = this.heap[parent];
        this.heap[parent] = this.heap[child];
        this.heap[child] = temp;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return this.heap[0];
    }

    public T Pull()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T element = this.heap[0];
        this.Swap(0, this.Count - 1);
        this.heap.RemoveAt(this.Count - 1);
        //this.HeapifyDownRecursive(element);
        this.HeapifyDownIterative();

        return element;
    }

    private void HeapifyDownIterative()
    {
        int parent = 0;

        while (parent < this.Count / 2)
        {
            int child = parent * 2 + 1;

            if (child + 1 < this.Count)
            {
                int compareChildren = this.heap[child + 1].CompareTo(this.heap[child]);
                if (compareChildren > 0)
                {
                    child++;
                }
            }

            int compare = this.heap[child].CompareTo(this.heap[parent]);
            if (compare > 0)
            {
                this.Swap(parent, child);
            }

            parent = child;
        }
    }

    public T[] toArray()
    {
        return this.heap.ToArray();
    }
}
