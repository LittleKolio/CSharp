using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample_Exam_2_June2016
{
    class Exam_04_SoftUni_Coffee_Supplies
    {
        static void Main()
        {
            var person = new Dictionary<string, string>();
            var coffee = new Dictionary<string, int>();

            string[] delim = Console.ReadLine().Split(' ');
            string perDelim = delim[0];
            string cofDelim = delim[1];
            //Console.WriteLine (perDelim);
            //Console.WriteLine (cofDelim);
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "end of info")
                    break;

                //Console.WriteLine (per + "\n" + cof);

                if (text.Contains(perDelim))
                {
                    int start = text.IndexOf(perDelim);
                    string per = text.Substring(0, start);
                    string cof = text.Substring(start + perDelim.Length);
                    if (person.ContainsKey(per))
                        person[per] = cof;
                    else
                        person.Add(per, cof);
                }
                else if (text.Contains(cofDelim))
                {
                    int start = text.IndexOf(cofDelim);
                    string cof = text.Substring(0, start);
                    int quan = int.Parse(text.Substring(start + cofDelim.Length));
                    if (coffee.ContainsKey(cof))
                        coffee[cof] += quan;
                    else
                        coffee.Add(cof, quan);
                }
            }
            foreach (var item in person.Values)
            {
                if (!coffee.ContainsKey(item))
                    coffee.Add(item, 0);
            }

            foreach (var item in coffee)
            {
                if (item.Value <= 0)
                    Console.WriteLine("Out of " + item.Key);
            }


            while (true)
            {
                string text = Console.ReadLine();
                if (text == "end of week")
                    break;
                string[] temp = text.Split(' ');
                string per = temp[0];
                int quan = int.Parse(temp[1]);
                coffee[person[per]] -= quan;
                if (coffee[person[per]] <= 0)
                    Console.WriteLine("Out of " + person[per]);
            }

            List<KeyValuePair<string, int>> orderCoffee = coffee
                .OrderByDescending(x => x.Value)
                .ToList();
            Console.WriteLine("Coffee Left:");
            foreach (var item in orderCoffee)
            {
                if (item.Value > 0)
                    Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
            List<KeyValuePair<string, string>> orderPersone = person
                .OrderBy(x => x.Value)
                .ThenByDescending(x => x.Key)
                .ToList();
            Console.WriteLine("For:");
            foreach (var item in orderPersone)
            {
                if (coffee[item.Value] > 0)
                    Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
        }
    }
}
