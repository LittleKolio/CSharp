namespace Exercise_03_Iterator_Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ListIterator : IListIterator
    {
        private IList<string> collection;
        private int index;

        public ListIterator(IEnumerable<string> collection)
        {
            InitializeCollection(collection);
            this.index = 0;
        }

        public bool HasNext() => this.index + 1 < this.collection.Count;

        public bool Move()
        {
            bool next = this.HasNext();
            if (next)
            {
                this.index++;
            }
            return next;
        }

        public string Print()
        {
            return this.collection[this.index];
        }

        private void InitializeCollection(IEnumerable<string> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(
                    "Collection cannot be null!");
            }
            this.collection = new List<string>();
        }
    }
}
