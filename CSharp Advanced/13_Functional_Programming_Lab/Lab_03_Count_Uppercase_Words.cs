using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Lab
{
    class Lab_03_Count_Uppercase_Words
    {
        static void Main()
        {
            Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w.First()))
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
