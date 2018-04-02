namespace Reflection_Exercises
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(
            IRepository repository,
            IUnitFactory unitFactory
            )
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            //first char to upper
            string cmdName = CultureInfo
                .CurrentCulture
                .TextInfo
                .ToTitleCase(commandName) +
                "Command";

            object[] cmdParams =
            {
                data
            };

            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == cmdName);

            if (commandType == null)
            {
                throw new InvalidOperationException(
                    "Invalid command");
            }

            IExecutable currentCommand = 
                (IExecutable)Activator.CreateInstance(commandType, cmdParams);

            return InjectDependencies(currentCommand);
        }

        private IExecutable InjectDependencies(IExecutable currentCommand)
        {
            FieldInfo[] fields = currentCommand
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute<InjectAttribute>().Count() != 0)
                .ToArray();

            FieldInfo[] fieldsType = this.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);


            foreach (FieldInfo field in fields)
            {
                field.SetValue(
                    currentCommand,
                    fieldsType.First(f => f.FieldType == field.FieldType).GetValue(this)
                    );
            }

            return currentCommand;
        }
    }
}
