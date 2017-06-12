namespace SoftUniADO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_07_Find_Employees_Period
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            var employees = context.Employees
                .Where(e =>
                    e.Projects.Any(p =>
                        p.StartDate.Year >= 2001 &&
                        p.StartDate.Year <= 2003
                    ) && e.Projects.Count > 0)
                //.OrderBy(e => e.FirstName)
                .Take(30);

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Manager.FirstName}");
                foreach (var pro in emp.Projects)
                {
                    Console.Write($"--{pro.Name}");
                    Console.Write($" {pro.StartDate:M/d/yyyy h:mm:ss tt}");
                    Console.Write($" {pro.EndDate:M/d/yyyy h:mm:ss tt}");
                    Console.WriteLine();
                }
            }

            /*
            foreach (var emp in context.Employees)
            {
                if (emp.Projects.All(p =>
                    p.StartDate.Year >= 2001 &&
                    p.StartDate.Year <= 2003))
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Manager.FirstName}");

                    foreach (var pro in emp.Projects)
                    {
                        Console.WriteLine($"--{pro.Name} {pro.StartDate:M/d/yyyy h:mm:ss tt} {pro.EndDate:M/d/yyyy h:mm:ss tt}");
                    }
                }
            }
            */
        }
    }
}
