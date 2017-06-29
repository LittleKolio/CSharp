using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes_Lab
{
    class StartUp
    {
        static void Main()
        {
            #region Test 2.Methods
            /*
            BankAccount acc = new BankAccount();
            acc.ID = 1;
            acc.Deposit(15);
            acc.Withdraw(5);
            Console.WriteLine(acc.ToString());
            */
            #endregion

            Dictionary<int, BankAccount> accounts 
                = new Dictionary<int, BankAccount>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] formatInput = input
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                string command = formatInput[0];

                switch (command)
                {
                    case "Create": Create(formatInput, accounts); break;
                    case "Deposit": Deposit(formatInput, accounts); break;
                    case "Withdraw": Withdraw(formatInput, accounts); break;
                    case "Print": Print(formatInput, accounts); break;
                }
            }
        }

        private static void Print(string[] formatInput, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(formatInput[1]);
            if (accounts.ContainsKey(id))
            { Console.WriteLine(accounts[id].ToString()); }
            else
            { Console.WriteLine("Account does not exist"); }
        }

        private static void Withdraw(string[] formatInput, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(formatInput[1]);
            double amount = double.Parse(formatInput[2]);
            if (accounts.ContainsKey(id))
            {
                if (accounts[id].Balance < amount)
                { Console.WriteLine("Insufficient balance"); }
                else
                { accounts[id].Withdraw(amount); }
            }
            else
            { Console.WriteLine("Account does not exist"); }
        }

        private static void Deposit(string[] formatInput, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(formatInput[1]);
            double amount = double.Parse(formatInput[2]);
            if (accounts.ContainsKey(id))
            { accounts[id].Deposit(amount); }
            else
            { Console.WriteLine("Account does not exist"); }
        }

        private static void Create(string[] formatInput, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(formatInput[1]);
            if (accounts.ContainsKey(id))
            { Console.WriteLine("Account already exists"); }
            else
            {
                BankAccount account = new BankAccount();
                account.ID = id;
                accounts.Add(id, account);
            }
        }
    }
}
