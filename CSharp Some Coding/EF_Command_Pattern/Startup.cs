namespace EFCommandPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var parser = new CommandParser();
            while (true)
            {
                var str = Console.ReadLine();
                if (str == "exit") { break; }
                var cmd = parser.Parse(str);
                cmd.Execute();
                Console.ReadKey(true);
            }
        }
    }
}
