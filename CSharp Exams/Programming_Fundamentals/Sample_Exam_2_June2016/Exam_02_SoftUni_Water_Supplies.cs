using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_2_June2016
{
    class Exam_02_SoftUni_Water_Supplies
    {
        public static void Main()
        {
            double water = double.Parse(Console.ReadLine());
            double[] bottles = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
            double capacity = double.Parse(Console.ReadLine());

            double waterNeeded = capacity * bottles.Length - bottles.Sum();
            if (waterNeeded <= water)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine("Water left: {0}l.", water - waterNeeded);
            }
            else
            {
                List<int> bottlesLeft = new List<int>();
                double fill = 0;
                if (water % 2 == 0)
                {
                    for (int b = 0; b < bottles.Length; b++)
                    {
                        fill += capacity - bottles[b];
                        if (water < fill)
                        {
                            bottlesLeft.Add(b);
                        }
                    }
                }
                else if (water % 2 != 0)
                {
                    for (int b = bottles.Length - 1; b >= 0; b--)
                    {
                        fill += capacity - bottles[b];
                        if (water < fill)
                        {
                            bottlesLeft.Add(b);
                        }
                    }
                }
                double moreWater = waterNeeded - water;
                Print(bottlesLeft, moreWater);
            }
        }
        static void Print(List<int> bottlesLeft, double moreWater)
        {
            Console.WriteLine("We need more water!");
            Console.WriteLine("Bottles left: {0}", bottlesLeft.Count);
            Console.WriteLine("With indexes: " + string.Join(", ", bottlesLeft));
            Console.WriteLine("We need {0} more liters!", moreWater);
        }
    }
}
