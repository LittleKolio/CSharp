namespace Exercise_03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomStack<T> : IEnumerable<T>, ICustomStack<T>
    {
        private List<T> list;

        public CustomStack()
        {
            this.list = new List<T>();
        }

        public int LastIndex => this.list.Count - 1;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.LastIndex; i > -1; i--)
            {
                yield return this.list[i];
            }
        }

        public T Pop()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException(
                    "No elements");
            }

            T element = this.list[this.LastIndex];
            this.list.RemoveAt(this.LastIndex);
            return element;
        }

        public void Push(params T[] args)
        {
            this.list.AddRange(args);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
