using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    public class City
    {
        public City()
        {
            District = new List<long>();
        }
        public string Name { get; set; }
        public List<long> District { get; set; }

        public override string ToString()
        {
            return $"{Name}: " + string.Join(" ", District);
        }
    }

    class Lab_08_Map_Districts
    {
        static void Main()
        {
            string cities = Console.ReadLine();
            long populationLimit = long.Parse(Console.ReadLine());

            /*
            var result = cities
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(
                    str => str.Split(':')[0],
                    str => int.Parse(str.Split(':')[1]))
                .Select(group => new KeyValuePair<string, int[]>(
                    group.Key,
                    group.ToArray()))
                .Where(pair => pair.Value.Sum() > populationLimit)
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
            */

            /*
            var result = cities
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(str => new
                {
                    Name = str.Split(':')[0],
                    Population = long.Parse(str.Split(':')[1])
                })
                .GroupBy(obj => obj.Name)
                .Select(group => new City
                {
                    Name = group.Key,
                    District = group
                        .Select(obj => obj.Population)
                        .OrderByDescending(popu => popu)
                        .Take(5)
                        .ToList()
                })
                .Where(city => city.District.Sum() > populationLimit)
                .OrderByDescending(city => city.District.Sum())
                .ToList();
            */

            var result = cities
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(str => new
                {
                    Name = str.Split(':')[0],
                    Population = long.Parse(str.Split(':')[1])
                })
                .GroupBy(
                    obj => obj.Name,
                    obj => obj.Population,
                    (name, dist) => new City
                    {
                        Name = name,
                        District = dist
                            .OrderByDescending(pop => pop)
                            .Take(5)
                            .ToList()
                    })
                .Where(city => city.District.Sum() > populationLimit)
                .OrderByDescending(city => city.District.Sum())
                .ToList();


            foreach (var city in result)
            {
                Console.WriteLine("" + city);
            }
        }
    }
}
