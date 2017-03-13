namespace SoftUniADO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class Exercise_13_Find_Employees_FirstName_starting_SA
    {
        static void Main()
        {
            //string test1 = "safgfd gfdgd";
            //string test2 = "fgfd asgfdgd";
            //string test3 = "eeasfgfd gfdgd";

            //if (Search(test1)) { Console.WriteLine("stana"); }
            //else {  Console.WriteLine("neeeee"); }

            var context = new SoftUniEntities();
            var emps = context.Employees
                .Where(e => 
                    e.FirstName
                    .ToLower()
                    .StartsWith("sa")
                );

            foreach (var e in emps)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary})");
            }
        }

        static bool Search(string str)
        {
            Regex rgx = new Regex(@"^(sa)(.*)$", RegexOptions.IgnoreCase);
            var match = rgx.Match(str);
            return match.Success;
        }
    }
}
