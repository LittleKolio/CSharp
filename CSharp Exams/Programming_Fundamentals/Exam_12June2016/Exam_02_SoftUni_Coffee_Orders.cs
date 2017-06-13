using System;
using System.Globalization;

namespace Exam_12June2016
{
    class Exam_02_SoftUni_Coffee_Orders
    {
        static void Main()
        {
            int order = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < order; i++)
            {
                decimal price = decimal.Parse(Console.ReadLine());
                string date = Console.ReadLine();
                DateTime newDate = DateTime.ParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture);
                int days = DateTime.DaysInMonth(newDate.Year, newDate.Month);
                int count = int.Parse(Console.ReadLine());
                decimal money = (days * count) * price;
                Console.WriteLine($"The price for the coffee is: ${money:F2}");
                sum += money;
            }
            Console.WriteLine($"Total: ${sum:F2}");
        }
    }
}
