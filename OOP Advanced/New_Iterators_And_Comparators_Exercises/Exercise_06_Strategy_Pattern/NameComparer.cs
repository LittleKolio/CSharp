namespace Exercise_06_Strategy_Pattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            string xName = x.Name.ToLower();
            string yName = y.Name.ToLower();

            int result = xName.Length.CompareTo(yName.Length);

            if (result == 0)
            {
                result = xName[0].CompareTo(yName[0]);
            }

            return result;
        }
    }
}
