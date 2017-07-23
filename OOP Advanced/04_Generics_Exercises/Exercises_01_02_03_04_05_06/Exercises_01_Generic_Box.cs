namespace Generics_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_01_Generic_Box
    {
        static void Main()
        {
            int num = 123123;
            Box<int> testNum = new Box<int>(num);
            Console.WriteLine(testNum);

            string str = "life in a box";
            Box<string> testStr = new Box<string> (str);
            Console.WriteLine(testStr);
        }
    }
}
