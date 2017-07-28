namespace Iterators_And_Comparators_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_02_Collection
    {
        static void Main()
        {
            string[] elements = Console.ReadLine()
                .Split(' ')
                .Skip(1)
                .ToArray();

            ListyIterator<string> list = new ListyIterator<string>(elements);

            string command;
            while (!(command = Console.ReadLine()).Equals("END"))
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(list.Print());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "PrintAll":
                        foreach (var item in list)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
