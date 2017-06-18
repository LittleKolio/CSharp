using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    class Lab_08_Map_Districts
    {
        static void Main()
        {
            //List<KeyValuePair<string, int>> input = Console.ReadLine()
            //    .Split(new[] { ' ' },
            //        StringSplitOptions.RemoveEmptyEntries)
            //    .Select(str => new KeyValuePair<string, int>(
            //        str.Split(':')[0],
            //        int.Parse(str.Split(':')[1])))
            //    .ToList();

            string cities = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());

            var result = cities
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(
                    str => str.Split(':')[0],
                    str => int.Parse(str.Split(':')[1]))
                .Select(group => new KeyValuePair<string, int[]>(
                    group.Key,
                    group.ToArray()))
                .Where(pair => pair.Value.Sum() > population)
                .OrderByDescending(pair => pair.Value.Sum())
                .ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value
                        .OrderByDescending(pop => pop)
                        .Take(5)
                        .ToArray());

            foreach (var city in result)
            {
                Console.WriteLine($"{city.Key}: " + string.Join(" ", city.Value));
            }
        }
    }
}
