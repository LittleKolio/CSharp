namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsoleWriter : IWriter
    {
        public void WriteEmptyLine() => Console.WriteLine();

        //public void PrintStudent(KeyValuePair<string, List<int>> student)
        //{
        //    this.WriteOneLineMessage($"{student.Key} - {string.Join(", ", student.Value)}");
        //}

        public void WriteException(params string[] arguments)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (string exMessage in arguments)
            {
                Console.WriteLine(exMessage);
            }

            Console.ForegroundColor = currentColor;
        }

        public void WriteMessage(params string[] arguments)
        {
            Console.Write(string.Join(" ", arguments));
        }

        public void WriteOneLineMessage(params string[] arguments)
        {
            foreach (string message in arguments)
            {
                Console.WriteLine(message);
            }
        }
    }
}
