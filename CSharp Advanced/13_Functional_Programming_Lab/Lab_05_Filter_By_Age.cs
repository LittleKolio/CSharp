using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Lab
{
    class Lab_05_Filter_By_Age
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();
            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries);
                people.Add(input[0], int.Parse(input[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> CustomFunction = CustomOrder(condition, age);
            Action<KeyValuePair<string, int>> CustomAction = CustomFormat(format);

            foreach (var person in people)
            {
                if (CustomFunction(person.Value))
                {
                    CustomAction(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CustomFormat(string format)
        {
            switch (format)
            {
                case "name age": return f => Console.WriteLine($"{f.Key} - {f.Value}"); break;
                case "name": return f => Console.WriteLine($"{f.Key}"); break;
                case "age": return f => Console.WriteLine($"{f.Value}"); break;
                default: return null;
            }
        }

        private static Func<int, bool> CustomOrder(string conditin, int age)
        {
            switch (conditin)
            {
                case "younger": return a => a < age; break;
                case "older": return a => a >= age; break;
                default: return null;
            }
        }
    }
}
