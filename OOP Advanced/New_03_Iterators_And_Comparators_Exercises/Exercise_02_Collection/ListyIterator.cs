namespace Exercise_02_Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ListyIterator<T> : IEnumerable<T>, ICustom
    {
        private IList<T> list;
        private int currentIndex;

        public ListyIterator(IEnumerable<T> collection)
        {
            this.list = new List<T>(collection);
            this.currentIndex = 0;
        }

        public T Current => this.list[this.currentIndex];

        public IEnumerator<T> GetEnumerator()
        {
            //for (int i = 0; i < this.list.Count; i++)
            //{
            //    yield return this.list[i];
            //}

            int index = this.currentIndex;
            this.currentIndex = -1;

            while (this.Move())
            {
                yield return this.Current;
            }

            this.currentIndex = index;
        }

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

        public void PrintAll()
        {
            string result = string.Join(" ", this);
            Console.WriteLine(result);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
