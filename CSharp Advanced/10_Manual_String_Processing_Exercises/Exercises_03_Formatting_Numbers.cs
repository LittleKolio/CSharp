using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Exercises
{
    class Exercises_03_Formatting_Numbers
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, 
                    StringSplitOptions.RemoveEmptyEntries);

            string binary = Convert.ToString(int.Parse(input[0]), 2);
            if (binary.Length >= 10)
            {
                binary = binary.Substring(0, 10);
            }
            else
            {
                binary = binary.PadLeft(10, '0');
            }

            string format = "|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|";
            string textLine = string.Format(
                format, 
                int.Parse(input[0]), 
                binary, 
                double.Parse(input[1]), 
                double.Parse(input[2]));

            Console.WriteLine(textLine);
        }
    }
}
