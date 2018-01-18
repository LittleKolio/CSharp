namespace Exercises_06_Implement_ReversedList_T
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] arr;
        private int count;
        private int capacity;

        public ReversedList(int capacity = 2)
        {
            this.arr = new T[capacity];
            this.count = 0;
            this.capacity = capacity;
        }

        public int Count
        {
            get { return this.count; }
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public T this[int index]
        {
            get
            {
                if (index > this.count - 1 || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid index: " + index);
                }

                return this.arr[this.count - 1 - index];
            }
            set
            {
                if (index > this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalid index: " + index);
                }

                this.arr[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.count + 1 >= this.capacity)
            {
                this.Grow();
            }

            this[this.count] = item;
            this.count++;
        }

        private void Grow()
        {
            T[] extendedArr = new T[this.capacity * 2];
            Array.Copy(this.arr, extendedArr, this.count);

            this.arr = extendedArr;
            this.capacity *= 2;
        }

        public T RemoveAt(int index)
        {
            int reverseIndex = this.count - 1 - index;

            T item = this[reverseIndex];
            this[reverseIndex] = default(T);

            this.ShiftLeft(reverseIndex);

            this.count--;
            if (this.count <= this.capacity / 3 &&
                this.capacity > 2)
            {
                this.Shrink();
            }

        return item;
        }

        private void Shrink()
        {
            T[] shrinkedArr = new T[this.capacity / 2];
            Array.Copy(this.arr, shrinkedArr, this.count);

            this.arr = shrinkedArr;
            this.capacity /= 2;
        }

        private void ShiftLeft(int reverseIndex)
        {
            for (int i = reverseIndex; i < this.count - 1; i++)
            {
                this[i] = this[i + 1];
            }
            this[this.count - 1] = default(T);
        }

        //public static void Main(string[] args)
        //{
        //}

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
