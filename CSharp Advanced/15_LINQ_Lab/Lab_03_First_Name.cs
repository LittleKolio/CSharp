using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    class Lab_03_First_Name
    {
        static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            //string chars = Console.ReadLine()
            //    .Replace(" ", string.Empty);

            HashSet<char> chars = new HashSet<char>(
                Console.ReadLine()
                .Replace(" ", string.Empty));

            string result = names.Where(name => 
                chars.Contains(char.ToLower(name.First())))
                .ToList()
                .OrderBy(name => name)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
