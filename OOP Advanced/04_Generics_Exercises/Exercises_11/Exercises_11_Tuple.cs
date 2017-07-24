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

            string[] inputLine1 = Console.ReadLine()
                .Split(' ');

            name = inputLine1[0] + " " + inputLine1[1];
            string address = inputLine1[2];

            CustomTuple<string, string> personInfo = new CustomTuple<string, string>(
                name, address);

            Console.WriteLine(personInfo);

            string[] inputLine2 = Console.ReadLine()
                .Split(' ');

            name = inputLine2[0];
            int liters = int.Parse(inputLine2[1]);

            CustomTuple<string, int> drinking = new CustomTuple<string, int>(
                name, liters);

            Console.WriteLine(drinking);

            string[] inputLine3 = Console.ReadLine()
                .Split(' ');

            int num1 = int.Parse(inputLine3[0]);
            double num2 = double.Parse(inputLine3[1]);

            CustomTuple<int, double> numbers = new CustomTuple<int, double>(
                num1, num2);

            Console.WriteLine(numbers);
        }
    }
}
