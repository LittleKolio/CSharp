namespace OOP_Intro
{
    using System;
    using System.Collections.Generic;
    using Classes;

    class Exercise_04_Students
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end") { break; }

                Student stu = new Student(input);
            }

            Console.WriteLine(Student.number);
        }
    }
}
