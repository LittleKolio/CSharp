namespace Gringotts.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    class Exercise_19_Deposits_Sum_Ollivander_Family
    {
        static void Main()
        {
            var creator = "Ollivander family";

            using (var context = new GringottsContext())
            {
                var result = context.WizzardDeposits
                    .Where(w => w.MagicWandCreator == creator)
                    .GroupBy(w => w.DepositGroup)
                    .Select(t => new
                    {
                        DepositSum = t.Sum(a => a.DepositAmount),
                        DepositGrup = t.FirstOrDefault().DepositGroup
                    })
                    .OrderByDescending(x => x.DepositSum)
                    .ToList();
                foreach (var r in result)
                {
                    Console.WriteLine($"{r.DepositGrup} - {r.DepositSum}");
                }
            }
        }
    }
}
