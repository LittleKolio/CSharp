namespace Defining_Classes_Exercises
{
    using Classes;
    using System;
    using System.Reflection;

    class Exercises_03_Oldest_Family_Member
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
                    .Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(int.Parse(input[1]), input[0]);
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
