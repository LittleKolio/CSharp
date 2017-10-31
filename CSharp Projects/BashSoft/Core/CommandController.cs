namespace BashSoft.Core
{
    using Commands;
    using IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandController
    {
        private string[] delimiter;
        private List<string> inputList;
        private Type[] assemblyTypes;

        public CommandController()
        {
            this.delimiter = new string[] { " " };
            this.inputList = new List<string>();
            this.assemblyTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes();
        }

        public ICmd Run(string input)
        {
            SplitInputString(input);

            string strCommand = this.inputList[0].ToLower();

            CmdEnum code;
            if (!Enum.TryParse(strCommand, true, out code))
            {
                throw new ArgumentException(
                    CustomMessages.CommandDontExist);
            }

            Type type = this.assemblyTypes
                .FirstOrDefault(tp => tp.GetCustomAttributes(typeof(CmdAttribute))
                    .Any(attr => ((CmdAttribute)attr).KeyCode == code));

            object[] paramsArray = default(object[]);

            if (this.inputList.Count > 1)
            {
                ParameterInfo[] commandParams = type
                    .GetConstructors()
                    .FirstOrDefault()
                    .GetParameters();

                paramsArray = new object[commandParams.Length];

                for (int i = 0; i < commandParams.Length; i++)
                {
                    Type paramType = commandParams[i].ParameterType;
                    paramsArray[i] = Convert.ChangeType(inputList[i + 1], paramType);
                }
            }

            ICmd command = (ICmd)Activator.CreateInstance(type, paramsArray);

            return command;
        }

        private void SplitInputString(string input)
        {
            this.inputList = input.Split(this.delimiter,
                StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
