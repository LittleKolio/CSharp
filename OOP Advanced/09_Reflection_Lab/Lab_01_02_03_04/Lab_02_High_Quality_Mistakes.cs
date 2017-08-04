namespace Reflection_Lab.Lab_02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_02_High_Quality_Mistakes
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
