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
        private Type[] assemblyTypes;

        public CommandController()
        {
            this.assemblyTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes();
        }

        public ICmd Run(string input)
        {
            string[] list = FormatInput.SplitText(input, " ");

            string strCommand = list[0].ToLower();

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

<<<<<<< HEAD
            if (list.Length > 0)
=======
            if (this.inputList.Count > 1)
>>>>>>> master
            {
                ParameterInfo[] commandParams = type
                    .GetConstructors()
                    .FirstOrDefault()
                    .GetParameters();

                paramsArray = new object[commandParams.Length];

                for (int i = 0; i < commandParams.Length; i++)
                {
                    Type paramType = commandParams[i].ParameterType;
                    paramsArray[i] = Convert.ChangeType(list[i + 1], paramType);
                }
            }

            ICmd command = (ICmd)Activator.CreateInstance(type, paramsArray);

            return command;
        }
    }
}
