using System;
using System.Collections.Generic;
using System.Linq;

public class Sorter
{
    public static ICustomList<T> Sort<T>(ICustomList<T> list)
        where T : IComparable
    {
        IList<T> temp = list.OrderBy(e => e).ToList();
        return new CustomList<T>(temp);
    }
}