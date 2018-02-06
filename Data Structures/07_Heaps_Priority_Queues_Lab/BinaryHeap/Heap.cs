using System;

public static class Heap<T> 
    where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Swap(arr, 0, i);
            HeapifyDownIterative(arr, i);
        }
    }

    private static void HeapifyDownIterative(T[] arr, int index)
    {
        int parent = 0;
        int child = parent * 2 + 1;

        while (child < index)
        {
            if (child + 1 < index)
            {
                int compareChildren = arr[child + 1].CompareTo(arr[child]);
                if (compareChildren > 0)
                {
                    child++;
                }
            }

            int compare = arr[child].CompareTo(arr[parent]);
            if (compare > 0)
            {
                Swap(arr, parent, child);
            }

            parent = child;
            child = parent * 2 + 1;
        }
    }

    private static void Swap(T[] arr, int parent, int child)
    {
        T temp = arr[parent];
        arr[parent] = arr[child];
        arr[child] = temp;
    }
}
