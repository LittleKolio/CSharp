namespace Practical_Exam_11February2018
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam_04_Hit_List
    {
        public static Dictionary<string, Dictionary<string, string>> list;
        public static void Main()
        {
            list = new Dictionary<string, Dictionary<string, string>>();
            int targetIndex = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] tokens = input.Split("=:;".ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                if (!list.ContainsKey(name))
                {
                    list.Add(name, new Dictionary<string, string>());
                }

                for (int i = 1; i < tokens.Length; i += 2)
                {
                    string key = tokens[i];
                    string value = tokens[i + 1];
                    if (!list[name].ContainsKey(key))
                    {
                        list[name].Add(key, string.Empty);
                    }
                    list[name][key] = value;
                }
            }

            string kill = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .FirstOrDefault();

            Console.WriteLine($"Info on {kill}:");
            foreach (KeyValuePair<string, string> info in list[kill].OrderBy(i => i.Key))
            {
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }


            int sumKey = list[kill].Keys.Select(k => k.Length).Sum();
            int sumValue = list[kill].Values.Select(v => v.Length).Sum();
            int sum = sumKey + sumValue;

            Console.WriteLine($"Info index: {sum}");
            if (sum >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - sum} more info.");
            }
        }
    }
}
