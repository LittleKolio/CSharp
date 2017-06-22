using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_1_From_19June2016
{
    class Exam_04_Cubic_Assault
    {
        public const long e6 = (long)(1e+6);

        static void Main()
        {
            string[] list = { "Green", "Red", "Black" };

            Dictionary<string, Dictionary<string, long>> regions 
                = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "count em all") { break; }

                string[] formatInput = input
                    .Split(new string[] { " -> " },
                    StringSplitOptions.RemoveEmptyEntries);

                string region = formatInput[0];
                string meteor = formatInput[1];
                long value = long.Parse(formatInput[2]);

                if (!regions.ContainsKey(region))
                {
                    regions.Add(region,
                        new Dictionary<string, long>
                        {
                             { "Black", 0 }, { "Red", 0 }, { "Green", 0 }
                        });
                }
                regions[region][meteor] += value;

                for (int i = 0; i < list.Length - 1; i++)
                {
                    long temp = regions[region][list[i]] / e6;
                    if (temp > 0)
                    {
                        regions[region][list[i + 1]] += temp;
                        regions[region][list[i]] %= e6;
                    }
                    
                }
            }

            foreach (var region in 
                regions
                .OrderByDescending(r => r.Value["Black"])
                .ThenBy(r => r.Key.Length)
                .ThenBy(r => r.Key))
            {
                Console.WriteLine(region.Key);

                region.Value
                    .OrderByDescending(m => m.Value)
                    .ThenBy(m => m.Key)
                    .ToList()
                    .ForEach(meteor => Console.WriteLine($"-> {meteor.Key} : {meteor.Value}"));
            }
        }
    }
}
