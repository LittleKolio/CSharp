namespace Trash.Ex06_Functional_Programming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex03_Custom_Min_Function
    {
        public static void Main()
        {
            Func<int, int> be = n => n;

            int num = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(be)
                .FirstOrDefault();

            Console.WriteLine(num);
        }
    }
}
