namespace Generics_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_11_Tuple
    {
        static void Main()
        {
            string name;

            string[] inputLine1 = SplitInput(Console.ReadLine(), " ");
            string[] inputLine2 = SplitInput(Console.ReadLine(), " ");
            string[] inputLine3 = SplitInput(Console.ReadLine(), " ");

            name = inputLine1[0] + " " + inputLine1[1];
            string address = inputLine1[2];

            CustomTuple<string, string> personInfo = new CustomTuple<string, string>(name, address);
            Console.WriteLine(personInfo);

            name = inputLine2[0];
            int liters = int.Parse(inputLine2[1]);
            CustomTuple<string, int> drinking = new CustomTuple<string, int>(name, liters);
            Console.WriteLine(drinking);

            int num1 = int.Parse(inputLine3[0]);
            double num2 = double.Parse(inputLine3[1]);

            CustomTuple<int, double> numbers = new CustomTuple<int, double>(num1, num2);
            Console.WriteLine(numbers);
        }

        public static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
