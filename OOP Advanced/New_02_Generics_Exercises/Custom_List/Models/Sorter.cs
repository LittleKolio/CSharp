namespace Custom_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Sorter
    {
        public static ICustomList<T> Sort<T>(ICustomList<T> list)
            where T : IComparable
        {
            IEnumerable<T> collection = list.OrderBy(e => e);
            return new CustomList<T>(collection);
        }
    }
}
