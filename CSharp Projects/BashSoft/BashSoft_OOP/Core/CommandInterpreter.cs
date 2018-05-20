namespace BashSoft_OOP.Core
{
    using Interfaces;
    using StaticData;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Using reflection we find the type name who match the input and return executable (interface) of that command.
    /// We using ServiceProvider for constructor injection to create instance of the command.
    /// </summary>

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;
        private Type[] commandTypes;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.commandTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes();
        }

        public IExecutable Interpreter(string[] arguments)
        {
            string commandInput = this.InputCommandformat(arguments[0]);

            Type commandType = this.commandTypes
                .FirstOrDefault(t => t.Name == commandInput);

            if (commandType == null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.command_DoseNotExist, arguments[0]));
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.command_IsNotExecutable, arguments[0]));
            }

            ParameterInfo[] commandTypeParameters = commandType
                .GetConstructors()
                .FirstOrDefault()
                .GetParameters();

            object[] parameters = new object[commandTypeParameters.Length];
            parameters[0] = arguments.Skip(1).ToArray();

            for (int i = 1; i < commandTypeParameters.Length; i++)
            {
                Type parameterType = commandTypeParameters[i].ParameterType;
                parameters[i] = this.serviceProvider.GetService(parameterType);
            }

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, parameters);

            return command;
        }

        private string InputCommandformat(string input)
        {
            return CultureInfo
                .CurrentCulture
                .TextInfo
                .ToTitleCase(input)
                + "Command";
        }

        //public void Interpreter(string cmd, string[] tokens)
        //{
        //    switch (cmd)
        //    {

        //        //change the current directory by an absolute path
        //        case "": break;

        //        //download a file
        //        case "": break;

        //        //download file asynchronously
        //        case "downloadAsynch": break;

        //        //help
        //        case "": break;
        //    }
        //}
    }
}
