namespace Generics_Lab.Lab_03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_03_Generic_Scale
    {
        static void Main()
        {
            Scale<int> test = new Scale<int>(4, 1);
            Console.WriteLine(test.GetHavier());
        }
    }
}
