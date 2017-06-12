namespace Employees.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration 
        : DbMigrationsConfiguration<EmployeesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EmployeesContext context)
        {
            var empList = new List<Employee>();
            empList.Add(new Employee
            {
                Firstname = "Steve",
                Lastname = "Jobbsen",
                Salary = 1.34m,
                Birthday = DateTime.ParseExact("01 01 2009", "dd MM yyyy", null)
            });

            empList.Add(new Employee
            {
                Firstname = "Stephen",
                Lastname = "Bjorn",
                Salary = 4300.00m,
                Birthday = DateTime.ParseExact("01 01 1999", "dd MM yyyy", null)
            });

            empList.Add(new Employee
            {
                Firstname = "Kirilyc",
                Lastname = "Lefi",
                Salary = 4400.00m,
                Birthday = DateTime.ParseExact("01 01 1989", "dd MM yyyy", null)
            });

            empList.Add(new Employee
            {
                Firstname = "Carl",
                Lastname = "Kormac",
                Salary = 2.02m,
                Birthday = DateTime.ParseExact("01 01 1979", "dd MM yyyy", null)
            });

            empList.Add(new Employee
            {
                Firstname = "Jurgen",
                Lastname = "Straus",
                Salary = 1000.45m,
                Birthday = DateTime.ParseExact("01 01 1979", "dd MM yyyy", null)
            });

            empList.Add(new Employee
            {
                Firstname = "Moni",
                Lastname = "Kozinac",
                Salary = 2030.99m,
                Birthday = DateTime.ParseExact("01 01 1979", "dd MM yyyy", null)
            });

            empList.Add(new Employee
            {
                Firstname = "Kopp",
                Lastname = "Spidok",
                Salary = 2000.21m,
                Birthday = DateTime.ParseExact("01 01 1979", "dd MM yyyy", null)
            });
            foreach (var e in empList)
            {
                context.Employees.AddOrUpdate(x => 
                new { x.Firstname, x.Lastname}, e);
            }
            context.SaveChanges();
            
            string[] subList1 = 
            {
                "Stephen Bjorn",
                "Kirilyc Lefi"
            };
            foreach (var e in context.Employees.Where(e => 
            subList1.Contains(e.Firstname + " " + e.Lastname)))
            {
                e.Manager = context.Employees.Single(m => 
                (m.Firstname + " " + m.Lastname) == "Steve Jobbsen");
            }
            context.SaveChanges();

            string[] subList2 = 
            {
                "Jurgen Straus",
                "Moni Kozinac",
                "Kopp Spidok"
            };
            foreach (var e in context.Employees.Where(e =>
            subList2.Contains(e.Firstname + " " + e.Lastname)))
            {
                e.Manager = context.Employees.Single(m => 
                (m.Firstname + " " + m.Lastname) == "Carl Kormac");
            }
            context.SaveChanges();
        }
    }
}
