using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets_And_Dictionaries_Exercises
{
    class Exercises_04_Count_Symbols
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<char, int> dic = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dic.ContainsKey(input[i]))
                {
                    dic.Add(input[i], 1);
                }
                else
                {
                    dic[input[i]]++;
                }
            }

            foreach (var item in dic.OrderBy(e => e.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
