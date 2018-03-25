namespace Generics_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_06_Generic_Count_Method_Strings
    {
        static void Main()
        {
            IList<string> list = new List<string>();

            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                list.Add(Console.ReadLine());
            }

            string element = Console.ReadLine();

            Console.WriteLine(CountElements(list, element));
        }

        private static int CountElements<T>
            (IList<T> list, T element)
            where T : IComparable
        {
            return list.Count(b => b.CompareTo(element) > 0);
        }
    }
}
