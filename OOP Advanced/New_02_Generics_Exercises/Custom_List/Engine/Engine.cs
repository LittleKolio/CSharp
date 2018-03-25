namespace Custom_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private ICustomList<string> list;

        public Engine()
        {
            this.list = new CustomList<string>();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = this.SplitInput(input, " ");
                string cmd = tokens[0];

                switch (cmd)
                {
                    case "Add":
                        this.list.Add(tokens[1]);
                        break;
                    case "Remove":
                        this.list.Remove(int.Parse(tokens[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(this.list.Contains(tokens[1]));
                        break;
                    case "Swap":
                        this.list.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(this.list.CountGreaterThan(tokens[1]));
                        break;
                    case "Max":
                        Console.WriteLine(this.list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(this.list.Min());
                        break;
                    case "Print":
                        Console.WriteLine(this.list);
                        break;
                    case "Sort":
                        this.list = Sorter.Sort(this.list);
                        break;
                }
            }
        }

        public string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
