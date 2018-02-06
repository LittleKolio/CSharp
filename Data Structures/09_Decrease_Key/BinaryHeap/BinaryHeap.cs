namespace BinaryHeap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

        //public void DecreaseKey(T element)
        //{

        //}

        public void Insert(T element)
        {
            this.heap.Add(element);
            this.HeapifyUp_Iterative(this.Count - 1);
        }

        private void HeapifyUp_Iterative(int index)
        {
            int child = index;
            int parent = (child - 1) / 2;

            while (parent >= 0 && child > 0 &&
                this.Compare(parent, child) > 0)
            {
                this.Swap(parent, child);

                child = parent;
                parent = (child - 1) / 2;
            }
        }

        private void Swap(int parent, int child)
        {
            T element = this.heap[parent];
            this.heap[parent] = this.heap[child];
            this.heap[child] = element;
        }

        private int Compare(int parent, int child)
        {
            return this.heap[parent].CompareTo(this.heap[child]);
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
            this.HeapifyDown_Iterative();

            return element;
        }

        private void HeapifyDown_Iterative()
        {
            int parent = 0;
            int child = parent * 2 + 1;

            while (parent < this.Count / 2)
            {
                if (child + 1 < this.Count &&
                    this.Compare(child + 1, child) > 0)
                {
                    child++;
                }

                if (this.Compare(parent, child) > 0)
                {
                    this.Swap(parent, child);
                }

                parent = child;
                child = parent * 2 + 1;
            }
        }
    }
}
