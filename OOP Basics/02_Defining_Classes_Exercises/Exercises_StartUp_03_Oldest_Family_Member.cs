using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes_Exercises
{
    class Exercises_StartUp_03_Oldest_Family_Member
    {
        static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            int count = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                family.AddMember(new Person(int.Parse(input[1]), input[0]));
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}
