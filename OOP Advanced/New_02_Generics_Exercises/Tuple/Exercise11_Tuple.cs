namespace Tuple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercise11_Tuple
    {
        public static void Main()
        {

            string[] line1 = SplitInput(Console.ReadLine(), " ");
            string[] line2 = SplitInput(Console.ReadLine(), " ");
            string[] line3 = SplitInput(Console.ReadLine(), " ");

            CustomTuple<string, string> tuple1 = new CustomTuple<string, string>(line1[0] + " " + line1[1], line1[2]);
            CustomTuple<string, int> tuple2 = new CustomTuple<string, int>(line2[0], int.Parse(line2[1]));
            CustomTuple<int, double> tuple3 = new CustomTuple<int, double>(int.Parse(line3[0]), double.Parse(line3[1]));

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }

        public static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
