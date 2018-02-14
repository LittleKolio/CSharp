namespace _01_Defining_Classes_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab02_Methods
    {
        public static void Main()
        {
            BankAccount acc = new BankAccount();

            acc.Id = 1;
            acc.Deposit(15);
            acc.Withdraw(10);

            Console.WriteLine(acc);
        }
    }
}
