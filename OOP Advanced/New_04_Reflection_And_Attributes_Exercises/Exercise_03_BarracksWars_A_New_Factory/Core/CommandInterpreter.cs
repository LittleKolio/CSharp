namespace Exercise_03_BarracksWars_A_New_Factory.Core
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
        private const string nameSpace = "Exercise_03_BarracksWars_A_New_Factory.Core.Commands.{0}";

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

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            //first char to upper
            commandName = CultureInfo
                .CurrentCulture
                .TextInfo
                .ToTitleCase(commandName) + "Command";

            Type type = Type.GetType(string.Format(nameSpace, commandName));

            //Type commandType = Assembly
            //    .GetExecutingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(t => t.Name == commandName);

            if (type == null)
            {
                throw new ArgumentException(
                    "Invalid command type!");
            }

            if (!typeof(Command).IsAssignableFrom(type))
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

            Command command = (Command)Activator.CreateInstance(type, argsCommand);
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
