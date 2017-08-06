using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing_Exercises.Exercises_01
{
    class StartUp
    {
        static void Main()
        {
            int[] arr1 = { 1, 2, 3, 9000 };
            int[] arr2 = { 88888888, 1, 2, 3, 9000, 324, 756, 9, 303, 3546, 7, 2345, 678, 54, 324, 5, 5342, 3524, 3524, 3524 };


            Database test = new Database(arr1);
            test.Add(32312);
            Console.WriteLine( );
        }

        private static void Print(IEnumerable<int> arr)
        {
            Console.WriteLine(string.Join(Environment.NewLine, arr));
        }
    }
}
