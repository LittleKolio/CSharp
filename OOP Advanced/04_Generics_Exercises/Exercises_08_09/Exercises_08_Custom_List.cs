namespace Generics_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_08_Custom_List
    {
        static void Main()
        {
            ICustomList<string> list = new CustomList<string>();

            string input;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] tokens = input
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                object stringbuilder = null;
                switch (tokens[0])
                {
                    case "Add":
                        list.Add(tokens[1]);
                        break;
                    case "Remove":
                        list.Remove(int.Parse(tokens[1]));
                        break;
                    case "Contains":
                        string result = list.Contains(tokens[1]).ToString();
                        Console.WriteLine(char.ToUpper(result[0]) + result.Substring(1));
                        break;
                    case "Swap":
                        list.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "Greater":
                        int count = list.CountGreaterThan(tokens[1]);
                        Console.WriteLine(count);
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Print":
                        Console.WriteLine(string.Join(Environment.NewLine, list));
                        break;
                }
            }
        }
    }
}
