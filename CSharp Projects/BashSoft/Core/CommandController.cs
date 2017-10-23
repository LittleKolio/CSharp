namespace BashSoft.Core
{
    using Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandController
    {
        //private Dictionary<string, ICommand> commandList;
        private List<string> commandList;

        public CommandController()
        {
            this.commandList = new List<string>();
            //this.Initialize();
        }

        public ICommand Run(string input)
        {
            this.commandList = input.Split(new[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries).ToList();
            string str = this.commandList[0];
            this.commandList.Remove(str);

            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => 
                    ((CmdAttribute)t.GetCustomAttribute(typeof(CmdAttribute), true)).Input 
                    == str);

            //var type = Assembly
            //    .ReflectionOnlyLoad("BashSoft")
            //    .GetTypes()
            //    .FirstOrDefault(t => t.GetCustomAttributesData().First().ConstructorArguments.First().Value.ToString() == "mkdir");

            object[] paramsArray = default(object[]);

            if (this.commandList.Count > 0)
            {
                ParameterInfo[] commandParams = type
                    .GetConstructors()
                    .FirstOrDefault()
                    .GetParameters();

                paramsArray = new object[commandParams.Length];

                for (int i = 0; i < commandParams.Length; i++)
                {
                    Type paramType = commandParams[i].ParameterType;
                    paramsArray[i] = Convert.ChangeType(commandList[i], paramType);
                }
            }

            ICommand command = (ICommand)Activator.CreateInstance(type, paramsArray);

            return command;

            //if (!commandList.ContainsKey(command))
            //{
            //    return new NotFound(this.list);
            //}
            //else
            //{
            //    return this.commandList[command].Create(this.list);
            //}
        }

        //private void Initialize()
        //{
        //    this.commandList = new Dictionary<string, string>
        //    {
        //        { "mkdir", "CreateDirectorty" },
        //        { "test", new TestCommand() }
        //    };
        //}
    }
}
