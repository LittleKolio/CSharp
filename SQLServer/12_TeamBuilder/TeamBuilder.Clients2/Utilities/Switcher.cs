namespace TeamBuilder.Clients2.Utilities
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Commands;

    public class Switcher
    {
        public string GetCommand(string input)
        {
            var result = string.Empty;

            var inputParam = input.Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            var cmd = inputParam.Length > 0 ? inputParam[0] : string.Empty;
            var cmdParam = inputParam.Skip(1).ToArray();

            switch (cmd)
            {
                case "exit":
                    var exit = new CmdExit();
                    result = exit.Execute(cmdParam);
                    break;

                case "RegisterUser":
                    var registerUser = new CmdRegisterUser();
                    result = registerUser.Executer(cmdParam);
                    break;

                default: throw new NotSupportedException(
                  $"Command {cmd} not valid!");
            }

            return result;
        }
    }
}
