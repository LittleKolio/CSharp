using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_And_Abstraction_Lab.StartUp
{
    public class Lab_02_Cars
    {
        static void Main()
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(tesla.ToString());
        }
    }
}
