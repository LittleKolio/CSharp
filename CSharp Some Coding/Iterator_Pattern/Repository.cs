namespace IteratorPattern
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Repository : IContainer
    {
        private ArrayList items;

        public Repository()
        {
            this.items = new ArrayList();
        }

        public IIterator GetIterator()
        {
            return new Iterator(this);
        }

        //private class Iterator : IIterator
        //{
        //    private int index;
        //    ...
        //}

        public int Count
        {
            get { return this.items.Count; }
        }

        public object this[int index]
        {
            get { return this.items[index]; }
            set { this.items.Insert(index, value); }
        }
    }
}
