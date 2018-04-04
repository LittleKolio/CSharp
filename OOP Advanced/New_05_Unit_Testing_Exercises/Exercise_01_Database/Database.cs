namespace Exercise_01_Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Database
    {
        private const int capacity = 16;

        private IList<int> integers;

        public Database()
        {
            this.integers = new List<int>();
        }

        public Database(params int[] integers) : this()
        {
            this.FillArray(integers);
        }

        public int Count => this.integers.Count;

        private void FillArray(params int[] integers)
        {
            if (integers.Length != capacity)
            {
                throw new InvalidOperationException(
                    $"Capacity is not {capacity}!");
            }

            for (int i = 0; i < integers.Length; i++)
            {
                this.Add(integers[i]);
            }
        }

        public void Add(int element)
        {
            if (this.Count == capacity)
            {
                throw new InvalidOperationException(
                    $"Capacity limit has been reached!");
            }

            this.integers.Add(element);
        }

        public void Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(
                    $"There is no integers!");
            }

            this.integers.RemoveAt(this.Count - 1);
        }

        public int[] Fetch()
        {
            return this.integers.ToArray();
        }
    }
}
