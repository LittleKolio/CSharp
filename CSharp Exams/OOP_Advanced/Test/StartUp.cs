using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class StartUp
    {
        static void Main(string[] args)
        {
            AutomaticMachine machine = new AutomaticMachine("eeee");
            Console.WriteLine(machine);
        }
    }
}
