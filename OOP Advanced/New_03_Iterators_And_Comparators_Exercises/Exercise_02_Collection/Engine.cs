namespace Exercise_02_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private ICustom collection;

        public void Run()
        {
            string input;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] tokens = this.SplitInput(input, " ");

                string result = string.Empty;

                try
                {
                    result = this.CommadSwitcher(tokens);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }
            }
        }

        private string CommadSwitcher(string[] tokens)
        {
            string result = string.Empty;
            string cmd = tokens[0];

            switch (cmd)
            {
                case "Create":
                    this.collection = new ListyIterator<string>(tokens.Skip(1));
                    break;

                case "Move":
                    result = this.collection.Move().ToString();
                    break;

                case "Print":
                    this.collection.Print();
                    break;

                case "HasNext":
                    result = this.collection.HasNext().ToString();
                    break;

                case "PrintAll":
                    this.collection.PrintAll();
                    break;

                default: break;
            }

            return result;
        }

        private string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
