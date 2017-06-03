using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Dictionaries
{
    class Lab04AcademyGraduation
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            SortedDictionary<string, List<double>> dic = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                List<double> list = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Replace(',', '.'))
                    .Select(double.Parse)
                    .ToList();

                dic.Add(name, list);
            }

            foreach (var item in dic)
            {
                Console.WriteLine(
                    $"{item.Key} is graduated with {item.Value.Average()}");
            }
        }
    }
}
