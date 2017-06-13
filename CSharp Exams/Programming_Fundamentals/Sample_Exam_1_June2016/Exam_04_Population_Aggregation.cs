using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_1_June2016
{
    class Exam_04_Population_Aggregation
    {
        public static void Main()
        {
            SortedDictionary<string, int> countryAndCitys = new SortedDictionary<string, int>();
            Dictionary<string, long> citysAndNumbers = new Dictionary<string, long>();

            while (true)
            {
                string[] text = Console.ReadLine().Split('\\');
                if (text[0] == "stop")
                    break;
                string country = RemoveChars(text[0]);
                string city = RemoveChars(text[1]);
                if (!char.IsUpper(country[0]))
                {
                    string old = country;
                    country = city;
                    city = old;
                }
                long people = long.Parse(text[2]);

                if (!countryAndCitys.ContainsKey(country))
                    countryAndCitys.Add(country, 0);
                if (citysAndNumbers.ContainsKey(city))
                {
                    citysAndNumbers[city] = people;
                }
                else
                {
                    citysAndNumbers.Add(city, people);
                    countryAndCitys[country]++;
                }

            }
            foreach (var item in countryAndCitys)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
            var c = citysAndNumbers.OrderBy(x => -x.Value).Take(3);
            foreach (var item in c)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
        static string RemoveChars(string word)
        {
            string[] split = word.Split("@#$&0123456789".ToArray());
            string concat = string.Concat(split);
            return concat;
        }
    }
}
