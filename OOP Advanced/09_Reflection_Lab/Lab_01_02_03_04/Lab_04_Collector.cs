namespace Reflection_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_04_Collector
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}
