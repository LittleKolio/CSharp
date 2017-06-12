using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Exercise_12_Increase_Salaries
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            string[] deps = {
                        "Engineering",
                        "Tool Design",
                        "Marketing",
                        "Information Services"
                    };

            var emps = context.Employees
                .Where(e => deps.Contains(e.Department.Name));

            foreach (var e in emps)
            {
                e.Salary *= (decimal)1.12;
            }

            context.SaveChanges();


            foreach (var e in emps)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:F6})");
            }

        }
    }
}
