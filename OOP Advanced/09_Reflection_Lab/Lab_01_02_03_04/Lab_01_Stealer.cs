namespace Reflection_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_01_Stealer
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
