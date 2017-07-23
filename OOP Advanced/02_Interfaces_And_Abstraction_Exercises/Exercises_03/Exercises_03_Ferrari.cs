namespace Interfaces_And_Abstraction_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_03_Ferrari
    {
        static void Main()
        {
            //string ferrariName = typeof(Ferrari).Name;
            //string iCarInterfaceName = typeof(ICar).Name;

            //bool isCreated = typeof(ICar).IsInterface;
            //if (!isCreated)
            //{
            //    throw new Exception("No interface ICar was created");
            //}

            string name = Console.ReadLine();
            Ferrari car = new Ferrari(name);
            Console.WriteLine(car);
        }
    }
}
