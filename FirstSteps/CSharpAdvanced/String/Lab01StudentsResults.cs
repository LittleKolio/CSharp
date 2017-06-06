using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Lab01StudentsResults
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Format(
                "{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|",
                "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            for (int i = 0; i < num; i++)
            {
                string[] studentResult = Console.ReadLine()
                    .Split(new[] { '-' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                string name = studentResult[0];
                double[] results = studentResult[1]
                    .Split(new[] { ',' }, 
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Console.WriteLine(string.Format(
                    "{0,-10}|{1,7:F2}|{2,7:F2}|{3,7:F2}|{4,7:F4}|",
                    name, results[0], results[1], results[2], results.Average()));
            }
        }
    }
}
