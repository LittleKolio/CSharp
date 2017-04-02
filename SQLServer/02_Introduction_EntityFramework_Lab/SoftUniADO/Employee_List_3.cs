using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Employee_List_3
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            context.Employees.Select(e => new {
                e.FirstName,
                e.LastName
            })
            .ToList()
            .ForEach(e => Console.WriteLine(e.FirstName + " " + e.LastName));
        }
    }
}
