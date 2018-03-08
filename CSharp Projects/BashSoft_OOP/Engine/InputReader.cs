namespace BashSoft_OOP
{
    using System;
    using System.Linq;

    public class InputReader
    {
        private const string endCommand = "quit";
        private CommandInterpreter commandInterpreter;

        public InputReader(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage(
                $"{FilesystemOperations.currentDirectory}> ");

            string input;
            while (!(input = Console.ReadLine()).Equals(
                endCommand, StringComparison.InvariantCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(input))
                {
                    OutputWriter.WriteException(
                        ExceptionMessages.command_Null);
                    continue;
                }

                string[] tokens = this.SplitInput(input, " ");
                string command = tokens[0];
                string[] parameters = tokens.Skip(1).ToArray();

                this.commandInterpreter.InterpredCommand(command, parameters);

                OutputWriter.WriteMessage(
                    $"{FilesystemOperations.currentDirectory}> ");
            }
        }

        private string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
