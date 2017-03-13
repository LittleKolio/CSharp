namespace OOP_Intro
{
    using System;
    using System.Collections.Generic;
    using Classes;

    class Exercise_06_Math_Utilities
    {
        static void Main()
        {

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0].ToLower() == "end") { break; }

                double first = double.Parse(input[1]);
                double second = double.Parse(input[2]);

                double result = .0;

                switch (input[0])
                {
                    case "Sum": result = MathUtil.Sum(first, second); break;
                    case "Subtract": result = MathUtil.Subtract(first, second); break;
                    case "Multiply": result = MathUtil.Multiply(first, second); break;
                    case "Divide": result = MathUtil.Divide(first, second); break;
                    case "Percentage": result = MathUtil.Percentage(first, second); break;
                }

                Console.WriteLine($"{result:F2}");
                Console.WriteLine();
            }
        }
    }
}
