using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sets_And_Dictionaries_Lab
{
    class Lab_03_Count_Same_Values_In_Array
    {
        static void Main()
        {
            string input = Console.ReadLine();
            
            //input = Regex.Replace(input, ",", ".");
            //double[] numbersArr = input
            //    .Split(new[] { ' ' }, 
            //        StringSplitOptions.RemoveEmptyEntries)
            //    .Select(double.Parse)
            //    .ToArray();

            double[] numbersArr = input
                .Split(new[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.Replace(',', '.'))
                .Select(e => double.Parse(e, CultureInfo.InvariantCulture))
                .ToArray();



            SortedDictionary<double, int> dic = new SortedDictionary<double, int>();

            foreach (double num in numbersArr)
            {
                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, 1);
                }
                else
                {
                    dic[num]++;
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
