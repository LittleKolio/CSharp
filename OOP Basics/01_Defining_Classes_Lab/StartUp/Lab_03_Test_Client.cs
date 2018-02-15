namespace Defining_Classes_Lab.StartUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab_03_Test_Client
    {
        public static Dictionary<int, BankAccount> accounts;
        static void Main()
        {
            accounts = new Dictionary<int, BankAccount>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                CommandInterpreter(tokens);
            }
        }

        private static void CommandInterpreter(string[] tokens)
        {
            string command = tokens[0];
            int id = int.Parse(tokens[1]);
            decimal amount = tokens.Length == 3
                ? decimal.Parse(tokens[2])
                : 0;

            switch (command)
            {
                case "Create": Create(id); break;
                case "Deposit": Deposit(id, amount); break;
                case "Withdraw": Withdraw(id, amount); break;
                case "Print": Print(id); break;
            }
        }

        private static void Print(int id)
        {
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine(accounts[id]);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(int id, decimal amount)
        {
            if (accounts.ContainsKey(id))
            {
                try
                {
                    accounts[id].Withdraw(amount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(int id, decimal amount)
        {
            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(int id)
        {
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                BankAccount account = new BankAccount();
                account.Id = id;
                accounts.Add(id, account);
            }
        }
    }
}
