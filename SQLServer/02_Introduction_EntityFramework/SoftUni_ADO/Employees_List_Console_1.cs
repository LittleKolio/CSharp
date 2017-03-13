namespace SoftUni_ADO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Employees_List_Console_1
    {
        static void Main()
        {
            //Console.WindowHeight = 50;
            //Console.BufferHeight = 300;

            //Console.WindowWidth = 80;
            //Console.BufferWidth = 80;

            //Console.WriteLine(Console.WindowHeight + " x " + Console.WindowWidth);
            //Console.WriteLine(Console.BufferHeight + " x " + Console.BufferWidth);

            //var key = Console.ReadKey();
            //Console.WriteLine(key.Key);

            var context = new SoftUniEntities();
            ListAll(context);
        }

        static void ListAll(SoftUniEntities context)
        {
            var projects = context.Projects.ToList();
            int page = 0;
            int maxPages = (int)Math.Ceiling(projects.Count / 14.0);

            while (true)
            {
                Console.Clear();

                Console.WriteLine($" ID | Project Name (Page {page + 1} of {maxPages})");
                Console.WriteLine("----+-------------");

                // Skip(14 * page).Take(14) -> preska4a 14 i vzima 14
                //za da printira 14 na stranica
                foreach (var p in projects.Skip(14 * page).Take(14))
                {
                    Console.WriteLine($"{p.ProjectID,4}| {p.Name}");
                }

                if (page + 1 >= maxPages)
                {
                    break;
                }

                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "UpArrow": if (page > 0) { page--; } break;
                    case "DownArrow": if (page + 1 <= maxPages) { page++; } break;
                    case "Escape": return;
                }
            }
        }
    }
}
