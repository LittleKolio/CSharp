using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Intro.Classes
{
    class MathUtil
    {
        public static double Sum(double first, double second)
        {
            return Math.Round(first + second, 2);
        }

        public static double Subtract(double first, double second)
        {
            return Math.Round(first - second, 2);
        }

        public static double Multiply(double first, double second)
        {
            return Math.Round(first * second, 2);
        }

        public static double Divide(double first, double second)
        {
            return Math.Round(first / second, 2);
        }

        public static double Percentage(double first, double second)
        {
            return Math.Round(Divide(Multiply(first, second), 100), 2);
        }
    }
}
