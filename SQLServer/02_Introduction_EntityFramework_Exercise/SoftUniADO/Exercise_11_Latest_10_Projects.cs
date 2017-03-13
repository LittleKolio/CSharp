namespace SoftUniADO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_11_Latest_10_Projects
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var pros = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            //Console.BufferWidth = 1024;

            foreach (var p in pros)
            {
                Console.Write(p.Name + " " + p.Description);
                Console.Write($" {p.StartDate:M/d/yyyy h:mm:ss tt}");
                if (p.EndDate != null)
                {
                    Console.Write($" {p.EndDate:M/d/yyyy h:mm:ss tt}");
                }
                Console.WriteLine();
            }
        }
    }
}
