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
                @"..\..\..\BashSoft2\Resources\test1.txt",
                @"..\..\..\BashSoft2\Resources\test3.txt"
                );
        }
    }
}
