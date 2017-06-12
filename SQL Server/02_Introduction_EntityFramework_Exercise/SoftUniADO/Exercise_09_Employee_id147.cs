using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Exercise_09_Employee_id147
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            var emps = context.Employees.First(e => e.EmployeeID == 147);
            var pro = emps.Projects.OrderBy(p => p.Name);

            Console.WriteLine($"{emps.FirstName} {emps.LastName} {emps.JobTitle}");
            foreach (var p in pro)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
