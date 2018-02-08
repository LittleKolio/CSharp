namespace Trash.Ex06_Functional_Programming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex12_Inferno_III
    {
        public static void Main()
        {
            List<int> sequence = SplitInput(Console.ReadLine(), " ")
                .Select(int.Parse)
                .ToList();

            Dictionary<string, List<int>> toRemove = new Dictionary<string, List<int>>();

            string commands;
            while ((commands = Console.ReadLine()) != "Forge")
            {
                string[] tokens = SplitInput(commands, ";");

                string key = $"{tokens[1]} {tokens[2]}";

                if (tokens[0] == "Exclude")
                {
                    List<int> value = sequence
                        .Where(gem =>
                            {
                                int i = sequence.IndexOf(gem);
                                int left = (i - 1) < 0 ? 0 : sequence[i - 1];
                                int right = (i + 1) >= sequence.Count ? 0 : sequence[i + 1];
                                return SwitchFunc(tokens, left, gem, right);
                            })
                        .ToList();

                    if (value.Count > 0)
                    {
                        toRemove.Add(key, value);
                    }
                }

                if (tokens[0] == "Reverse")
                {
                    toRemove.Remove(key);
                }
            }

            foreach (List<int> arr in toRemove.Values)
            {
                sequence = sequence.Except(arr).ToList();
            }

            Console.WriteLine(string.Join(" ", sequence));
        }

        private static bool SwitchFunc(string[] tokens, int left, int gem, int right)
        {
            Func<int[], int, bool> func = (array, num) => array.Sum() == num;

            switch (tokens[1])
            {
                case "Sum Left":
                    return func(new int[] { left, gem, 0 }, int.Parse(tokens[2]));
                case "Sum Right":
                    return func(new int[] { 0, gem, right }, int.Parse(tokens[2]));
                case "Sum Left Right":
                    return func(new int[] { left, gem, right }, int.Parse(tokens[2]));
                default:
                    return false;
            }
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(), 
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
