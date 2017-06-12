using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Exercise_05_Employees_Seattle
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                //.Where(e => new string[] { "Research", "Development " }.Contains(e.Department.Name))
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (var e in employees)
            {
                Console.Write(e.FirstName + " " + e.LastName);
                Console.Write(" from " + e.Department.Name);
                Console.Write($" - ${e.Salary:F2}");
                Console.WriteLine();
            }
        }
    }
}
