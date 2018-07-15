namespace IteratorPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Iterator : IIterator
    {
        private Repository repo;
        private int index;

        public Iterator(Repository repo)
        {
            this.repo = repo;
            this.index = 0;
        }

        public object Current()
        {
            return this.repo[index];
        }

        public void First()
        {
            this.index = 0;
        }

        public bool IsDone()
        {
            bool isDone = false;

            if (this.index < 0 || this.index >= this.repo.Count)
            {
                isDone = true;
            }

            return isDone;
        }

        public void Last()
        {
            this.index = this.repo.Count - 1;
        }

        public void Next()
        {
            this.index++;
        }

        public void Previous()
        {
            this.index--;
        }
    }
}
