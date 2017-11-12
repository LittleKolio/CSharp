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
            Enum.TryParse(strCommand, true, out code);

            Type type = this.assemblyTypes
                .FirstOrDefault(tp => tp.GetCustomAttributes(typeof(CmdAttribute))
                    .Any(attr => ((CmdAttribute)attr).KeyCode == code));

            object[] paramsArray = default(object[]);

            if (list.Length > 0)
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
