using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Dictionaries
{
    class Exercises04CountSymbols
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
