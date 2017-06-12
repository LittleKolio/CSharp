

namespace Exercise_07_Gringotts_Database
{
    using Models;
    using System;
    using System.Collections.Generic;

    class Start
    {
        static void Main()
        {
            using (var context = new GringottsContext())
            {
                var dummbaaa = new WizardDeposit()
                {
                    FirstName = "Albus",
                    LastName = "Dumbledore",
                    MagicWandCreator = "Antioch Peverell",
                    MagicWandSize = 15,
                    DepositStartDate = new DateTime(2016, 10, 20),
                    DepositExpirationDate = new DateTime(2020, 10, 20),
                    DepositAmount = 20000.24m,
                    DepositCharge = .2m,
                    IsDepositExpired = false
                };

                context.WizardDeposits.Add(dummbaaa);
                context.SaveChanges();
            }
        }
    }
}
