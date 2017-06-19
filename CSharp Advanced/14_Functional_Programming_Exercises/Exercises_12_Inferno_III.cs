using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Exercises
{
    class Exercises_12_Inferno_III
    {
        public static int[] gems;
        static void Main()
        {
            gems = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<string, Dictionary<int, Predicate<int>>> commands
                = new Dictionary<string, Dictionary<int, Predicate<int>>>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] { ';' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0].ToLower() == "forge") { break; }

                string command = tokens[0].ToLower();
                string filter = tokens[1];
                int param = int.Parse(tokens[2]);

                Predicate<int> func = SwitchFunction(filter, param);

                if (command == "exclude")
                {
                    if (!commands.ContainsKey(filter))
                    {
                        commands.Add(filter,
                            new Dictionary<int, Predicate<int>>());
                    }

                    commands[filter].Add(param, func);
                }
                else
                {
                    commands[filter].Remove(param);
                }
            }

            List<int> result = Forge(commands);

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> Forge(Dictionary<string, Dictionary<int, Predicate<int>>> commands)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Length; i++)
            {
                bool validIndex = false;
                foreach (var command in commands)
                {
                    foreach (var filter in command.Value)
                    {
                        if (filter.Value(i))
                        {
                            validIndex = true;
                            break;
                        }
                    }
                }
                if (!validIndex)
                {
                    result.Add(gems[i]);
                }
            }

            return result;
        }

        private static Predicate<int> SwitchFunction(string filter, int param)
        {
            switch (filter)
            {
                case "Sum Left":
                    return index =>
                    {
                        int gem = index <= 0 
                            ? 0 
                            : gems[index - 1];
                        return (gem + gems[index]) == param;
                    };

                case "Sum Right":
                    return index =>
                    {
                        int gem = index >= gems.Length - 1 
                            ? 0 
                            : gems[index + 1];
                        return (gem + gems[index]) == param;
                    };

                case "Sum Left Right":
                    return index =>
                    {
                        int gemRight = index >= gems.Length - 1
                            ? 0
                            : gems[index + 1];
                        int gemLeft = index <= 0
                            ? 0
                            : gems[index - 1];
                        return (gemRight + gemLeft + gems[index]) == param;
                    };

                default: return null;
            }
        }
    }
}
