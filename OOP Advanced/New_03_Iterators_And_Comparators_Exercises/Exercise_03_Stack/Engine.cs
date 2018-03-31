namespace Exercise_03_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private CustomStack<int> collection;

        public Engine()
        {
            this.collection = new CustomStack<int>();
        }

        public void Run()
        {
            string input;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] tokens = this.SplitInput(input, ", ");

                try
                {
                    this.CommadSwitcher(tokens);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            this.Print();
            this.Print();
        }

        private void Print()
        {
            foreach (int element in this.collection)
            {
                Console.WriteLine(element);
            }
        }

        private void CommadSwitcher(string[] tokens)
        {
            string cmd = tokens[0];

            switch (cmd)
            {
                case "Push":
                    {
                        int[] args = tokens
                            .Skip(1)
                            .Select(int.Parse)
                            .ToArray();

                        this.collection.Push(args);
                    }
                    break;

                case "Pop":
                    this.collection.Pop();
                    break;

                default: break;
            }
        }

        private string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
