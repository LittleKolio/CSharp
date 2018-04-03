namespace Exercise_07_Inferno_Infinity.Core
{
    using Attributes;
    using Contracts;
    using Commands;
    using System;
    using System.Linq;
    using System.Globalization;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        //private IRepository repository;
        //private IUnitFactory unitFactory;
        
        //public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        //{
        //    this.repository = repository;
        //    this.unitFactory = unitFactory;
        //}

        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data)
        {
            string command = data[0];

            //first char to upper
            command = CultureInfo
                .CurrentCulture
                .TextInfo
                .ToTitleCase(command) + "Command";

            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == command);

            if (commandType == null)
            {
                throw new ArgumentException(
                    "Invalid CommandType!");
            }

            if (!typeof(Command).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException(
                    "CommandType don't inherit Command!");
            }

            //yes we know wath arguments the constructor needs
            object[] argsCommand =
            {
                data
                //, this.repository, this.unitFactory
            };

            Command command = (Command)Activator.CreateInstance(commandType, argsCommand);
            this.InjectDependenciest(command);
            return command;
        }

        private void InjectDependenciest(Command command)
        {
            FieldInfo[] commandFields = command
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttribute<InjectAttribute>() != null)
                .ToArray();

            //FieldInfo[] thisFields = this
            //    .GetType()
            //    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            //foreach (FieldInfo field in commandFields)
            //{
            //    field.SetValue(command, thisFields
            //        .FirstOrDefault(f => f.FieldType == field.FieldType)
            //        .GetValue(this));
            //}

            foreach (FieldInfo field in commandFields)
            {
                field.SetValue(command, this.serviceProvider.GetService(field.FieldType));
            }
        }
    }
}
