using System;
using System.Collections.Generic;

public class AgeComparator : IComparer<Person>
{
    public int Compare(Person first, Person second)
    {
        int result = first.Age - second.Age;
        return result;
    }
}