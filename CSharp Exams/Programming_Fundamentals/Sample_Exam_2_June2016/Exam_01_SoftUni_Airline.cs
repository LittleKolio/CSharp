using System;
using System.Linq;

namespace Sample_Exam_2_June2016
{
    class Exam_01_SoftUni_Airline
    {
        public static void Main()
        {
            int flight = int.Parse(Console.ReadLine());
            decimal[] profit = new decimal[flight];
            for (int f = 0; f < flight; f++)
            {
                decimal adultCount = decimal.Parse(Console.ReadLine());
                decimal adultTicked = decimal.Parse(Console.ReadLine());
                decimal youthCount = decimal.Parse(Console.ReadLine());
                decimal youthTicked = decimal.Parse(Console.ReadLine());
                decimal fuelPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPerHour = decimal.Parse(Console.ReadLine());
                decimal duration = decimal.Parse(Console.ReadLine());
                decimal expenses = fuelPrice * fuelPerHour * duration;
                decimal flightProfit = adultCount * adultTicked + youthCount * youthTicked;
                if (flightProfit >= expenses)
                {
                    Console.WriteLine("You are ahead with {0:F3}$.", flightProfit - expenses);
                }
                else
                {
                    Console.WriteLine("We've got to sell more tickets! We've lost {0:F3}$.", flightProfit - expenses);
                }
                profit[f] = flightProfit - expenses;
            }
            Console.WriteLine("Overall profit -> {0:F3}$.", profit.Sum());
            Console.WriteLine("Average profit -> {0:F3}$.", profit.Average());
        }
    }
}
