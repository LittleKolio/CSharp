namespace EFCommandPatternExtended
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

            var data = new MyData
            {
                MyNum = 33,
                MyStr = "Egati ludnicata"
            };

            while (true)
            {
                Console.Write("adide napi6i ne6o:");
                var str = Console.ReadLine();
                if (str == "exit") { break; }
                var cmd = parser.Parse(str, data);
                cmd.Execute();
            }
        }
    }

    public class MyData
    {
        public int MyNum { get; set; }
        public string MyStr { get; set; }
    }
}
