using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Exercises
{
    class Exercises_09_List_Of_Predicates
    {
        static void Main()
        {
            int end = int.Parse(Console.ReadLine());

            List<int> dividersArr = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int, bool> func = (num, div) => num % div == 0;

            List<int> result = new List<int>();

            for (int num = 1; num <= end; num++)
            {
                bool temp = true;
                foreach (var div in dividersArr)
                {
                    if (!func(num, div))
                    {
                        temp = false;
                        break;
                    }
                }
                if (temp)
                {
                    result.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
