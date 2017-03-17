namespace SoftUni.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using System.IO;
    using System.Data.SqlClient;
    using System.Data.Entity;

    class Exercise_18_Employees_Maximum_Salaries
    {
        static void Main()
        {
            var lowSalary = new SqlParameter("@lowSalary", 30000);
            var highSalary = new SqlParameter("@highSalary", 70000);

            var context = new SoftUniContext();

            var query = File.ReadAllText(
                @"..\..\Clients\Exercise_18_Employees_Maximum_Salaries.sql");
            context.Database
                .SqlQuery<Bahmamamu>(query, lowSalary, highSalary)
                .ToList()
                .ForEach(r => Console.WriteLine($"{r.Name} - {r.Salary}"));


            //var employees = context.Employees
            //    .OrderBy(e => e.DepartmentID)
            //    .ThenByDescending(e => e.Salary)
            //    .ToList();

            //var list = new List<Employee>();
            //list.Add(employees[0]);
            //for (var i = 0; i < employees.Count; i++)
            //{
            //    if (list[list.Count - 1].DepartmentID !=
            //        employees[i].DepartmentID)
            //    {
            //        list.Add(employees[i]);
            //    }
            //}

            //foreach (var e in list)
            //{
            //    if (e.Salary < 30000 || e.Salary > 70000)
            //    {
            //        Console.WriteLine($"{e.Department.Name} - {e.Salary}");
            //    }
            //}

        }
    }
    class Bahmamamu
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
