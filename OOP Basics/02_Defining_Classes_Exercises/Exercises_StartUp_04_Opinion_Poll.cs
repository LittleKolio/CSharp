using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes_Exercises
{
    class Exercises_StartUp_04_Opinion_Poll
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                family.AddMember(new Person(int.Parse(input[1]), input[0]));
            }
            family.PeopleMoreThan30();
        }
    }
}
