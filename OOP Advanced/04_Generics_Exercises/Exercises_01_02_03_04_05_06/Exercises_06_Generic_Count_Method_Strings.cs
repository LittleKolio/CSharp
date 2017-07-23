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
            IList<Box<string>> list = new List<Box<string>>();

            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                list.Add(new Box<string>(Console.ReadLine()));
            }

            string element = Console.ReadLine();

            Console.WriteLine(CountElements<string>(list, element));
        }

        private static int CountElements<T>
            (IList<Box<T>> list, T element)
            where T : IComparable
        {
            return list.Count(b => b.Value.CompareTo(element) > 0);
        }
    }
}
