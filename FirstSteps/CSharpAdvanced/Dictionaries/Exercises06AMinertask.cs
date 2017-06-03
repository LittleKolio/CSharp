using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Dictionaries
{
    class Exercises06AMinertask
    {
        static void Main()
        {
            Dictionary<string, int> resource = new Dictionary<string, int>();

            string key = string.Empty;

            for (int i = 1; true; i++)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "stop") { break; }

                if (i % 2 != 0)
                {
                    if (!resource.ContainsKey(input))
                    {
                        resource.Add(input, 0);
                    }
                    key = input;
                }
                else
                {
                    resource[key] += int.Parse(input);
                }
            }

            foreach (var item in resource)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
