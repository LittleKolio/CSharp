namespace Exercise_01_ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ListyIterator<T> : ICustomEnumerator
    {
        private IList<T> list;
        private int currentIndex;

        public ListyIterator(IEnumerable<T> collection)
        {
            this.list = new List<T>(collection);
            this.currentIndex = 0;
        }

        public T Current => this.list[this.currentIndex];

        public bool HasNext() => this.currentIndex + 1 < this.list.Count;

        public bool Move()
        {
            bool result = this.HasNext();
            if (result)
            {
                this.currentIndex++;
            }
            return result;
        }
        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException(
                    "Invalid Operation!");
            }

            Console.WriteLine(this.Current);
        }
    }
}
