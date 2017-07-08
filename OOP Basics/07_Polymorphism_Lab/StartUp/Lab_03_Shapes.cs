namespace Polymorphism_Lab.StartUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_03_Shapes
    {
        static void Main()
        {
            Shape cir = new Circle(5);

            Console.WriteLine("{0:F2}", cir.CalculateArea());
            Console.WriteLine("{0:F2}", cir.CalculatePerimeter());
        }
    }
}
