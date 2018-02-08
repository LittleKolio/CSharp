namespace Trash.Ex06_Functional_Programming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex07_Predicate_For_Names
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            Func<string, bool> func = str => str.Length <= num;

            Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Where(func)
                .ToList()
                .ForEach(str => Console.WriteLine(str));
        }
    }
}
