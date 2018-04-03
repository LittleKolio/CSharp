namespace Exercise_07_Inferno_Infinity.Core
{
    using IO;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFormat format;
        private ICommandInterpreter commandInterpreter;

        public Engine(IReader reader, IWriter writer, IFormat format, ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.format = format;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string[] tokens = this.format.Format(
                    this.reader.Read(), "; ");

                

                Console.WriteLine(string.Join("-", tokens));
            }
        }
    }
}
