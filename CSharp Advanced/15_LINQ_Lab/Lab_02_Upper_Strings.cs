using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    class Lab_02_Upper_Strings
    {
        static void Main()
        {
            List<string> words = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            words.Select(word => word.ToUpper())
                .ToList()
                .ForEach(word => Console.Write(word + " "));
        }
    }
}
