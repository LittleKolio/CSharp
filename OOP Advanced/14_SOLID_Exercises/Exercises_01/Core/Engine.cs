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
        private Controller controller;
        private IReader reader;
        private IWriter writer;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, Controller controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.controller = controller;
        }

        public void Run()
        {
            this.isRunning = true;
            this.controller.InitilizeLogger(this.reader);

            while (this.isRunning)
            {
                string input = this.reader.ConsoleReader();
                if (input == "END")
                {
                    this.isRunning = false;
                    continue;
                }

                this.controller.SendMessageToLogger(input);
            }

            this.writer.ConsoleWriter(
                this.controller.GetLoggerInfo()
                );
        }
    }
}
