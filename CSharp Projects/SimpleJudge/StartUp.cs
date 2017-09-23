using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJudge
{
    public class StartUp
    {
        public static void Main()
        {
            Tester.CompareContent(
                @"..\..\data\test1.txt",
                @"..\..\data\test3.txt"
                );
        }
    }
}
