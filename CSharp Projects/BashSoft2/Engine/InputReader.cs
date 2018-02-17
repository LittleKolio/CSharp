namespace BashSoft2.Engine
{
    using IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class InputReader
    {
        private const string endCommand = "quit";

        public static void StartReadingCommands()
        {
            OutputWriter.WriteOneLineMessage(
                $"{SessionData.currentFolder}>");

            string input;
            while (!(input = Console.ReadLine()).Equals(
                endCommand, StringComparison.InvariantCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(input))
                {

                }

                string[] tokens = SplitInput(input, " ");
                string[] parameters = tokens.Skip(1).ToArray();

                CommandInterpreter.InterpredCommand(tokens[0], parameters);
            }
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
