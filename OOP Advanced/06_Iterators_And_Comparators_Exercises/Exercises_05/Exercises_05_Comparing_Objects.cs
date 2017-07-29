namespace Iterators_And_Comparators_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_05_Comparing_Objects
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            string input;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] personInfo = input
                    .Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person(
                    personInfo[0],
                    int.Parse(personInfo[1]),
                    personInfo[2]
                    ));
            }

            int index = int.Parse(Console.ReadLine());
            Person person = people[index - 1];

            int equal = 0;

            for (int p = 0; p < people.Count; p++)
            {
                //if (p != index - 1)
                //{
                //    int result = person.CompareTo(people[p]);
                //    if (result == 0) { equal++; }
                //}
                int result = person.CompareTo(people[p]);
                if (result == 0) { equal++; }
            }

            if (equal == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                //Console.WriteLine($"{equal} {people.Count - equal - 1} {people.Count}");
                Console.WriteLine($"{equal} {people.Count - equal} {people.Count}");
            }
        }
    }
}
