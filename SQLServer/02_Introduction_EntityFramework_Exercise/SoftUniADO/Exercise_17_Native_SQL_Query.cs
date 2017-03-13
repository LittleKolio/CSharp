using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Exercise_17_Native_SQL_Query
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            context.Projects.Count();


            var empsLinq = context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
                .Select(e => e.FirstName);

            var empsNative = context.Database.SqlQuery<string>(@"
select e.FirstName
from Projects as p
join EmployeesProjects as ep
	on ep.ProjectID = p.ProjectID
join Employees as e
	on e.EmployeeID = ep.EmployeeID
where year(p.StartDate) = 2002
");

            var timer = new Stopwatch();
            timer.Start();
            foreach (var e in empsNative)
            {
                Console.WriteLine(e);
            }
            timer.Stop();
            Console.WriteLine($"Native {timer.Elapsed}");

            timer.Start();
            foreach (var e in empsLinq)
            {
                Console.WriteLine(e);
            }
            timer.Stop();
            Console.WriteLine($"Linq {timer.Elapsed}");
        }
    }
}
