namespace Exercise_03_Array_Based_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArrayStack<T>
    {
        private T[] elements;
        private int count;
        private int capacity;
        private const int INITIAL_CAPACITY = 16;

        public ArrayStack(int capacity = INITIAL_CAPACITY)
        {
            this.elements = new T[capacity];
            this.capacity = capacity;
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Push(T element)
        {
            if (this.count + 1 >= this.capacity)
            {
                this.Grow();
            }

            this.elements[this.count] = element;
            this.count++;
        }
        public T Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[this.count - 1];
            this.elements[this.count - 1] = default(T);

            this.count--;

            return element;
        }
        public T[] ToArray()
        {
            T[] result = new T[this.count];
            Array.Copy(this.elements, result, this.count);

            return result;
        }

        private void Grow()
        {
            T[] extendedArr = new T[this.capacity * 2];
            Array.Copy(this.elements, extendedArr, this.count);

            this.elements = extendedArr;
            this.capacity *= 2;
        }

        //public static void Main(string[] args)
        //{
        //}
    }
}
