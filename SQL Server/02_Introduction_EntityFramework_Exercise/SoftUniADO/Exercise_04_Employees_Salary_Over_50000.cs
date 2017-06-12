using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Exercise_04_Employees_Salary_Over_50000
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => e.FirstName);

            foreach (var e in employees)
            {
                Console.WriteLine(e);
            }
        }
    }
}
