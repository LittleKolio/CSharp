using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Exercise_15_Delete_Project_Id
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var project = context.Projects.Find(2);

            foreach (var e in project.Employees)
            {
                e.Projects.Remove(project);
            }

            context.Projects.Remove(project);
            context.SaveChanges();

            var pros = context.Projects
                .Select(p => p.Name)
                .Take(10);

            foreach (var p in pros)
            {
                Console.WriteLine(p);
            }
        }
    }
}
