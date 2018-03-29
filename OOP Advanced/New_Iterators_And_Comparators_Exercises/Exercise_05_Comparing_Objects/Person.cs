namespace Exercise_05_Comparing_Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person : IComparable<Person>
    {
        public string Name { get; }
        public int Age { get; }
        public string Town { get; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            if (result == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }

            return result; 
        }
    }
}
