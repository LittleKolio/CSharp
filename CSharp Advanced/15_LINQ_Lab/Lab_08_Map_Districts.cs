using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    class Lab_08_Map_Districts
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(
                    str => str.Split(':')[0], 
                    str => int.Parse(str.Split(':')[1]));
        }
    }
}
