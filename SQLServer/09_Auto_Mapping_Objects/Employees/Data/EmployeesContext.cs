namespace Employees.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class EmployeesContext : DbContext
    {
        public EmployeesContext()
            : base("name=EmployeesContext")
        {
            Database.SetInitializer(
                //new DropCreateDatabaseAlways<EmployeesContext>()
                new MigrateDatabaseToLatestVersion<EmployeesContext, Configuration>()
                );
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }

}