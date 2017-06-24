using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sample_Exam_2_From_22August2016
{
    /// <summary>
    /// The valid input will come in the following format: "Grow <{regionName}> <{colorName}> {roseAmount}"
    /// The region names must always start with a capital English alphabet letter, and consist only of lowercase letters.
    /// The color's name must consist only of English alphabet letters and digits.
    /// The rose amount must be an integer.
    /// Any input that does NOT follow the rules must be ignored.
    /// If you receive an input with existent region, you should add the new color and roses to it.
    /// If even the color exists, increase their current value with the given one.
    /// The input ends when you receive the command "Icarus, Ignite!".
    /// </summary>
    /// <output>
    /// Print information about each region and its roses.
    /// Regions must be ordered by amount of roses they have, in descending order, as prime criteria and in alphabetical order, as secondary criteria.
    /// Their colors must be ordered by amount of roses, in ascending order, as prime criteria and in alphabetical order, as secondary criteria.
    /// The format of output is:
    /// "{region1Name}
    /// *--{color1Name} | {roseCount}
    /// *--{color2Name} | {roseCount}
    /// ..."
    /// </output>
    /// <remarks>
    /// The input lines can consist of any ASCII character.
    /// The input count of roses will be a valid integer in range [0, 2^31 – 1].
    /// Allowed time/memory: 100ms/16MB
    /// </remarks>
    class Exam_04_Ashes_Of_Roses
    {
        public static string pattern = 
            @"^Grow\s<(?<region>[A-Z][a-z]+)>\s<(?<color>[^\W_]+)>\s(?<amount>\d+)$";

        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> roses
                = new Dictionary<string, Dictionary<string, long>>();
            Regex regex = new Regex(pattern);

            string input;
            while ((input = Console.ReadLine()) != "Icarus, Ignite!")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string region = match.Groups["region"].Value;
                    string color = match.Groups["color"].Value;
                    long amount = long.Parse(match.Groups["amount"].Value);

                    if (!roses.ContainsKey(region))
                    { roses.Add(region, new Dictionary<string, long>()); }

                    if (!roses[region].ContainsKey(color))
                    { roses[region].Add(color, 0); }

                    roses[region][color] += amount;
                }
            }

            foreach (var region in 
                roses
                    .OrderByDescending(r => r.Value.Values.Sum())
                    .ThenBy(r => r.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var color in 
                    region.Value
                        .OrderBy(c => c.Value)
                        .ThenBy(c => c.Key))
                {
                    Console.WriteLine($"*--{color.Key} | {color.Value}");
                }
            }
        }
    }
}
