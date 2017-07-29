namespace Iterators_And_Comparators_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_06_Strategy_Pattern
    {
        static void Main()
        {
            SortedSet<Person> first = 
                new SortedSet<Person>(new NameComparator());
            SortedSet<Person> second =
                new SortedSet<Person>(new AgeComparator());

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                Person temp = new Person(tokens[0], int.Parse(tokens[1]));

                first.Add(temp);
                second.Add(temp);
            }

            Console.WriteLine(string.Join(Environment.NewLine, first));
            Console.WriteLine(string.Join(Environment.NewLine, second));
        }
    }
}
