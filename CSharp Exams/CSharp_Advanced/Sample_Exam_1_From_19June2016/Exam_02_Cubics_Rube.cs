using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_1_From_19June2016
{
    class Exam_02_Cubics_Rube
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<long> list = new List<long>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Analyze") { break; }
                
                int[] tempArr = input
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (tempArr.Take(3).All(num => (0 <= num && num < n)) && 
                    tempArr[3] != 0)
                {
                    list.Add(tempArr[3]);
                }
            }

            long sum = list.Sum();

            Console.WriteLine(sum);
            Console.WriteLine($"{Math.Pow(n, 3) - list.Count}");
        }
    }
}
