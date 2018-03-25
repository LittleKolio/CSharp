namespace Generic_Count_Method
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercise07_Generic_Count_Method_Doubles
    {
        public static void Main()
        {
            List<double> list = new List<double>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double input = double.Parse(Console.ReadLine());

            Console.WriteLine(Count(list, input));
        }

        public static int Count<U>(List<U> list, U input)
            where U : IComparable
        {
            //int count = 0;
            //foreach (U item in list)
            //{
            //    if (item.CompareTo(input) > 0)
            //    {
            //        count++;
            //    }
            //}
            //return count;

            return list.Count(e => e.CompareTo(input) > 0);
        }
    }
}
