namespace BashSoft_Basic
{
    using System;
    using System.Linq;

    public static class InputReader
    {
        private const string endCommand = "quit";

        public static void StartReadingCommands()
        {
            OutputWriter.WriteMessage(
                $"{FilesystemOperations.currentDirectory}> ");

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

                OutputWriter.WriteMessage(
                    $"{FilesystemOperations.currentDirectory}> ");
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
