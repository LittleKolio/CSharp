namespace Defining_Classes_Lab.StartUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_01_Define_Bank_Account_Class
    {
        static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.ID = 1;
            acc.Balance = 15;

            Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
        }
    }
}
