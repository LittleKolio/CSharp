﻿namespace Defining_Classes_Exercises
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Exercises_06_Company_Roster
    {
        static void Main()
        {
            List<Employee> listEmployees = new List<Employee>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                Employee employee = new Employee(
                    input[0],
                    decimal.Parse(input[1]),
                    input[2],
                    input[3]);

                if (input.Length > 4)
                {
                    short age;
                    if (short.TryParse(input[4], out age))
                    {
                        employee.Age = age;
                    }
                    else
                    {
                        employee.Email = input[4];
                    }
                }
                if (input.Length > 5)
                {
                    employee.Age = short.Parse(input[5]);
                }

                listEmployees.Add(employee);
            }


            var department = listEmployees
                .GroupBy(emp => emp.Department)
                .Select(group => new
                {
                    Name = group.Key,
                    AvgSalary = group.Average(emp => emp.Salary),
                    Employees = group.OrderByDescending(emp => emp.Salary).ToList()
                })
                .OrderByDescending(dep => dep.AvgSalary)
                .FirstOrDefault();

            Console.WriteLine("Highest Average Salary: " + department.Name);
            department
                .Employees
                .ForEach(emp => Console.WriteLine(emp.EmployeeInfo()));
        }
    }
}
