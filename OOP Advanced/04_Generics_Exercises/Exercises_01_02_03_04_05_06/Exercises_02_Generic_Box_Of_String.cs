namespace Generics_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_02_Generic_Box_Of_String
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                Box<string> str = new Box<string>(Console.ReadLine());
                Console.WriteLine(str);
            }
        }
    }
}
