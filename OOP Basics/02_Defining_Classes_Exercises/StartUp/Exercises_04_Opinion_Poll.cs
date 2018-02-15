namespace Defining_Classes_Exercises
{
    using Classes;
    using System;

    class Exercises_04_Opinion_Poll
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

                Person person = new Person(int.Parse(input[1]), input[0]);
                family.AddMember(person);
            }

            foreach (Person person in family.GetOlderThan30Members())
            {
                Console.WriteLine(person);
            }
        }
    }
}
