namespace Reflection_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_03_Mission_Private_Impossible
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}
