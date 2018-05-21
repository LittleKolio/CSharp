namespace BashSoft_OOP.IO
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class ConsoleWriter : IWriter
    {
        public void WriteEmptyLine() => Console.WriteLine();

        public void WriteException(params string[] arguments)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (string exMessage in arguments)
            {
                this.WriteOneLineMessage(exMessage);
            }

            Console.ForegroundColor = currentColor;
        }

        public void WriteMessage(params string[] arguments)
        {
            foreach (string message in arguments)
            {
                this.WriteOneLineMessage(message);
            }
        }

        public void WriteOneLineMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteAndWait(string message)
        {
            Console.Write(message);
        }

        public void WriteHelp(List<List<string>> commands)
        {
            foreach (List<string> command in commands)
            {
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;

                string commandLine = command[0].ToUpper() + " " + command[1];

                this.CutingLine(commandLine, "", 70);

                Console.ForegroundColor = currentColor;

                for (int i = 2; i < command.Count; i++)
                {
                    string line = "    " + command[i];

                    this.CutingLine(line, "    ", 60);
                }

                this.WriteEmptyLine();
            }
        }

        private void CutingLine(string line, string start, int length)
        {
            while (line.Length > length)
            {
                int index = line.LastIndexOf(' ', length);

                this.WriteOneLineMessage(line.Substring(0, index + 1));

                line = start + line.Substring(index + 1);
            }

            this.WriteOneLineMessage(line);
        }
    }
}
