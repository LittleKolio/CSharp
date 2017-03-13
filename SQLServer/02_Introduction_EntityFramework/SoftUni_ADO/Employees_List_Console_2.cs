namespace SoftUni_ADO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Employees_List_Console_2
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            ListAll(context);

            //ShowDetails(context, 5);
        }

        static void ListAll(SoftUniEntities context)
        {
            var projects = context.Projects.ToList();
            int projectId = 0;

            int pageSize = 14;
            int page = 0;
            int maxPages = (int)Math.Ceiling(projects.Count / (double)pageSize);
            int pointer = 1;

            while (true)
            {
                //reset console color
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                Console.WriteLine($" ID | Project Name (Page {page + 1} of {maxPages})");
                Console.WriteLine("----+-------------");

                int current = 1;
                foreach (var p in projects.Skip(pageSize * page).Take(pageSize))
                {
                    //reset console color
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        projectId = p.ProjectID;
                    }
                    Console.WriteLine($"{p.ProjectID,4}| {p.Name}");
                    current++;
                }

                if (page + 1 >= maxPages)
                {
                    break;
                }

                //wait for key press
                var key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                    case "UpArrow":
                        if (pointer > 1) { pointer--; }
                        else if (page > 1) { page--; pointer = 14; }
                        break;
                    case "DownArrow":
                        if (pointer < pageSize) { pointer++; }
                        else if (page + 1 <= maxPages) { page++; pointer = 1; }
                        break;
                    case "Enter": ShowDetails(context, projectId);
                        break;
                    case "Escape": return;
                }
            }
        }

        static void ShowDetails(SoftUniEntities context, int projectId)
        {
            var project = context.Projects.Find(projectId);
            var employees = project.Employees.ToList();
       
            //int employeeId = 0;

            int pageSize = 4;
            int page = 0;
            int maxPages = (int)Math.Ceiling(employees.Count / (double)pageSize);
            int pointer = 1;

            while (true)
            {
                //reset console color
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                Console.WriteLine($"ID: {project.ProjectID,4} | {project.Name}");
                Util_Emp_L_C_2.PrintLine();
                Console.WriteLine(project.Description);
                Util_Emp_L_C_2.PrintLine();
                Console.WriteLine($"{project.StartDate,-25} | {project.EndDate}");
                Util_Emp_L_C_2.PrintLine();
                Console.WriteLine($"Page {page + 1} of {maxPages}");
                Util_Emp_L_C_2.PrintLine();

                int current = 1;
                foreach (var e in employees.Skip(pageSize * page).Take(pageSize))
                {
                    //reset console color
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        //employeeId = e.EmployeeID;
                    }
                    Console.WriteLine($"{e.FirstName} {e.LastName}");
                    current++;
                }

                if (page >= maxPages)
                {
                    break;
                }

                //wait for key press
                var key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                    case "UpArrow":
                        if (pointer > 1) { pointer--; }
                        else if (page > 1) { page--; pointer = pageSize; }
                        break;
                    case "DownArrow":
                        if (pointer < pageSize) { pointer++; }
                        else if (page + 1 <= maxPages) { page++; pointer = 1; }
                        break;
                    //case "Enter":
                    //    ShowDetails(context, projectId);
                    //    break;
                    case "Escape": return;
                }
            }

        }
    }
}
