using Defining_Classes_Exercises.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes_Exercises
{
    class Exercises_StartUp_05_Date_Modifier
    {
        static void Main()
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            DateModifier dif = new DateModifier(dateOne, dateTwo);
            Console.WriteLine(dif.Difference);
        }
    }
}
