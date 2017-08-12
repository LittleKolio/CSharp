namespace SOLID_Exercises.Exercises_01.Core
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string input = this.reader.ConsoleReader();
                if (input == "END")
                {
                    this.isRunning = false;
                }


            }
        }
    }
}
