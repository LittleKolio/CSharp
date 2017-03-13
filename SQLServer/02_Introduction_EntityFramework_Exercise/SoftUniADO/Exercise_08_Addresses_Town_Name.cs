using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Exercise_08_Addresses_Town_Name
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Take(10);

            foreach (var adr in addresses)
            {
                Console.Write($"{adr.AddressText},");
                Console.Write($" {adr.Town.Name}");
                Console.Write($" - {adr.Employees.Count} employees");
                Console.WriteLine();
            }
        }
    }
}
