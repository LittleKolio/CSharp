using System;
using System.Collections.Generic;
using System.IO;
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
                Path.GetFullPath(@"..\..\..\BashSoft2\Resources\test1.txt"),
                Path.GetFullPath(@"..\..\..\BashSoft2\Resources\test3.txt")
                );
        }
    }
}
