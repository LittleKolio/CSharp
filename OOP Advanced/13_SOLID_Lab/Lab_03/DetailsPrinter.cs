namespace SOLID_Lab.Lab_03
{
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void printDetails()
        {
            //foreach (Employee employee in this.employees)
            //{
            //    if (employee is Manager)
            //    {
            //        this.PrintManager((Manager) employee);
            //    }
            //    else
            //    {
            //        this.PrintEmployee(employee);
            //    }
            //}

            foreach (Employee employee in this.employees)
            {
                Console.WriteLine(employee);
            }
        }

        //private void PrintEmployee(Employee employee)
        //{
        //    Console.WriteLine(employee.Name);
        //}

        //private void PrintManager(Manager manager)
        //{
        //    Console.WriteLine(manager.Name);
        //    Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));
        //}
    }
}