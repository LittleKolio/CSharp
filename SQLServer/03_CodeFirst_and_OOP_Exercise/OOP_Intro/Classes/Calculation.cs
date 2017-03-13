using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Intro.Classes
{
    class Calculation
    {
        const double Planck = 6.62606896e-34;
        const double Pi = 3.14159;

        public static double ReducedPlanck()
        {
            return Planck / 2 * Pi;
        }
    }
}
