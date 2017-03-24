namespace EFCommandPatternReflection
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

            var input = Console.ReadLine();
            var cmd = parser.Parse(input, data);
            cmd.Execute();
        }
    }

    public class MyData
    {
        public int MyNum { get; set; }
        public string MyStr { get; set; }
    }
}
