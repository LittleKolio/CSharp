namespace OOP_Intro
{
    using Classes;
    using System;
    using System.Collections.Generic;

    class Exercise_02_Create_Person_Constructors
    {
        static void Main()
        {

            string input = Console.ReadLine();

            Person per;
            int age = 0;
            string name = "";
            bool result;

            if (!string.IsNullOrEmpty(input))
            {
                string[] filter = input.Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);

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

            Print(per.Name, per.Age);

        }

        static void Print(string name, int age)
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
            Console.WriteLine(new string('-', 20));
        }

    }
}
