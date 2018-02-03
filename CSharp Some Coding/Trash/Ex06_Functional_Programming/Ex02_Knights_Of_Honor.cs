namespace Trash.Ex06_Functional_Programming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex02_Knights_Of_Honor
    {
        public static void Main()
        {
            Action<string> write = str => Console.WriteLine(str);

            Console.ReadLine()
                .Split()
                .Select(str => "Sir " + str)
                .ToList()
                .ForEach(write);
        }
    }
}
