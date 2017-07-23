using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Exercises
{
    class Exercises_03_Generic_Box_Of_Integer
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                Box<int> str = new Box<int>(
                    int.Parse(Console.ReadLine()));
                Console.WriteLine(str);
            }
        }
    }
}
