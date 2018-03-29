namespace Exercise_04_Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lake<T> : IEnumerable<T>
    {
        private IList<T> stones;

        public Lake(ICollection<T> stones)
        {
            this.stones = new List<T>(stones);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = 0;
            for (; index < this.stones.Count; index += 2)
            {
                yield return this.stones[index];
            }
            
            if (this.stones.Count % 2 == 0)
            {
                index -= 1;
            }
            else
            {
                index -= 3;
            }

            for (; index > 0; index -= 2)
            {
                yield return this.stones[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
