namespace SoftUniADO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_10_Departments_more_than_5_employees
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            var deps = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count);

            foreach (var d in deps)
            {
                Console.WriteLine(d.Name + " " + d.Employee.FirstName);
                foreach (var m in d.Employees)
                {
                    Console.Write(m.FirstName + " " + m.LastName);
                    Console.WriteLine(" " + m.JobTitle);
                }
            }
        }
    }
}
