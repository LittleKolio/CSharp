using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniADO
{
    class Exercise_14_First_Letter
    {
        static void Main()
        {
            var context = new GringottsContext();

            var wizs = context.WizzardDeposits
                .Where(w => w.DepositGroup == "Troll Chest")
                .Select(w => w.FirstName)
                .ToList()
                .Select(n => n[0])
                .Distinct()
                .OrderBy(w => w);

            foreach (var w in wizs)
            {
                Console.WriteLine(w);
            }
        }
    }
}
