namespace Functional_Programming_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_02_Knights_Of_Honor
    {
        static void Main()
        {
            Action<string> printAction = name => Console.WriteLine("Sir " + name);

            Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printAction);
        }
    }
}
