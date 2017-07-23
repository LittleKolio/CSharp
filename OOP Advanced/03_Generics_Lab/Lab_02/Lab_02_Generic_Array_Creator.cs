namespace Generics_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_02_Generic_Array_Creator
    {
        static void Main()
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
}
