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
                $"{SessionData.currentDirectory}>");

            string input;
            while (!(input = Console.ReadLine()).Equals(
                endCommand, StringComparison.InvariantCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(input))
                {
                    OutputWriter.DisplayException(
                        ExceptionMessages.commands_Null);
                    continue;
                }

                string[] tokens = SplitInput(input, " ");
                string command = tokens[0];
                string[] parameters = tokens.Skip(1).ToArray();

                CommandInterpreter.InterpredCommand(command, parameters);
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
