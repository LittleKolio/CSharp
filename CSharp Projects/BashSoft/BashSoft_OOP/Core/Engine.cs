namespace BashSoft_OOP.Core
{
    using System;
    using StaticData;
    using Util;
    using Interfaces;
    using IO.Interfaces;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;
        private IFilesystemManager filesystemManager;

        private IWriter writer;
        private IReader reader;

        public Engine(
            ICommandInterpreter commandInterpreter,
            IFilesystemManager filesystemManager,
            IWriter writer,
            IReader reader)
        {
            this.commandInterpreter = commandInterpreter;
            this.filesystemManager = filesystemManager;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                this.writer.WriteMessage(
                    $"{this.filesystemManager.CurrentDirectory}> ");

                string input = this.reader.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    this.writer.WriteException(ExceptionMessages.command_Null);
                    continue;
                }

                if (this.ShouldEnd(input))
                    break;

                string[] arguments = Utility.SplitInput(input, " ");

                try
                {
                    IExecutable executable = this.commandInterpreter.Interpreter(arguments);
                    executable.Execute();
                }
                catch (Exception ex)
                {
                    this.writer.WriteException(ex.Message);
                }
            }
        }

        private bool ShouldEnd(string input)
        {
            return input.Equals(Constants.Command_End,
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
