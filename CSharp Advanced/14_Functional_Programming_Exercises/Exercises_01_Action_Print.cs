using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Exercises
{
    class Exercises_01_Action_Print
    {
        static void Main()
        {
            //Action<string> printAction = name => Console.WriteLine(name);

            //Console.ReadLine()
            //    .Split(new[] { ' ' },
            //    StringSplitOptions.RemoveEmptyEntries)
            //    .ToList()
            //    .ForEach(printAction);

            string[] names = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Action<string> act = name => Console.WriteLine(name);

            PrintNames(names, act);
        }

        private static void PrintNames(string[] names, Action<string> act)
        {
            foreach (var name in names)
            {
                act(name);
            }
        }
    }
}
