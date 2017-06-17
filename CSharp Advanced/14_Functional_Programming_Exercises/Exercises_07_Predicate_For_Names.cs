using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Exercises
{
    class Exercises_07_Predicate_For_Names
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> isRgihtLen = name => name.Length <= length;

            PrintNames(names, isRgihtLen);
        }

        private static void PrintNames(string[] names, Predicate<string> isRgihtLen)
        {
            foreach (var name in names)
            {
                if (isRgihtLen(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
