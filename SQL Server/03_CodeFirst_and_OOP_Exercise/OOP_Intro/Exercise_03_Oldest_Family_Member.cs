namespace OOP_Intro
{
    using Classes;
    using System;
    using System.Collections.Generic;

    class Exercise_03_Oldest_Family_Member
    {
        static void Main()
        {

            int length = int.Parse(Console.ReadLine());

            Family ufff = new Family();

            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();

                Person per;
                int age = 0;
                string name = "";
                bool result;

                if (!string.IsNullOrEmpty(input))
                {
                    string[] filter = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (filter.Length == 1)
                    {
                        result = int.TryParse(filter[0], out age);

                        if (!result)
                        {
                            name = filter[0];
                            per = new Person(name);
                        }
                        else { per = new Person(age); }
                    }
                    else if (filter.Length > 1)
                    {
                        foreach (var element in filter)
                        {
                            result = int.TryParse(element, out age);
                            if (!result) { name = element; }
                        }
                        per = new Person(name, age);
                    }
                    else { per = new Person(); }
                }
                else { per = new Person(); }

                ufff.AddMember(per);
                Print(per, "Add new member.");
            }

            Print(ufff.GetOldestMember(), "Oldest member.");
        }

        static void Print(Person member, string description = "")
        {
            Console.WriteLine(description);
            Console.WriteLine($"Name: {member.Name}, Age: {member.Age}");
            Console.WriteLine(new string('-', 20));
        }
    }
}
