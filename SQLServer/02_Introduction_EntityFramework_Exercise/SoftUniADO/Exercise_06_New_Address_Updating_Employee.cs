using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Exercise_06_New_Address_Updating_Employee
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            /*
            var address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownID = 4;

            //context.Addresses.Add(address);
            //context.SaveChanges();

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;
            context.SaveChanges();
            */

            var employees = context.Employees
                .OrderByDescending(e => e.AddressID)
                .Take(10);

            foreach (var e in employees)
            {
                Console.WriteLine(e.Address.AddressText);
            }
        }
    }
}
