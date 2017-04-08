namespace TeamBuilder.Clients2.Utilities
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Commands;
    using System.Reflection;

    public class Switcher
    {
        public string GetCommand(string input)
        {
            var result = string.Empty;

            var inputParam = input.Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            var cmdString = inputParam.Length > 0 ? inputParam[0] : string.Empty;
            var cmdParam = inputParam.Skip(1).ToArray();

            // Get command's type.
            Type commandType = Type.GetType(
                $"TeamBuilder.Clients2.Commands.Cmd{cmdString}");

            // If command's type is not found – it is not valid command.
            if (commandType == null)
            {
                throw new NotSupportedException(
                    $"Command {cmdString} not supported!");
            }

            // Create instance of command with the type that we already extracted.
            object command = Activator.CreateInstance(commandType);

            // Get the method called “Execute” of the command.
            MethodInfo executeMethod = command.GetType().GetMethod("Execute");

            // Invoke the method we found passing the instance of the command and
            // array of all expected arguments that the method should take when it is invoked.
            result = executeMethod.Invoke(command, new object[] { cmdParam }) as string;

            #region Switch(cmd) Case
            /*
            switch (cmd)
            {
                //case "test":
                //    var test = new CmdTest();
                //    result = test.Execute(cmdParam);
                //    break;

                case "Disband":
                    var disband = new CmdDisband();
                    result = disband.Execute(cmdParam);
                    break;

                case "AcceptInvite":
                    var acceptInvite = new CmdAcceptInvite();
                    result = acceptInvite.Execute(cmdParam);
                    break;

                case "InviteToTeam":
                    var inviteUser = new CmdInviteToTeam();
                    result = inviteUser.Execute(cmdParam);
                    break;

                case "CreateTeam":
                    var createTeam = new CmdCreateTeam();
                    result = createTeam.Execute(cmdParam);
                    break;

                case "CreateEvent":
                    var createEvent = new CmdCreateEvent();
                    result = createEvent.Execute(cmdParam);
                    break;

                case "DeleteUser":
                    var deleteUser = new CmdDeleteUser();
                    result = deleteUser.Execute(cmdParam);
                    break;

                case "Logout":
                    var logoutUser = new CmdLogout();
                    result = logoutUser.Execute(cmdParam);
                    break;

                case "Login":
                    var loginUser = new CmdLogin();
                    result = loginUser.Execute(cmdParam);
                    break;

                case "Exit":
                    var exit = new CmdExit();
                    result = exit.Execute(cmdParam);
                    break;

                case "RegisterUser":
                    var registerUser = new CmdRegisterUser();
                    result = registerUser.Execute(cmdParam);
                    break;

                default: throw new NotSupportedException(
                  $"Command {cmd} not valid!");
            }
            */
            #endregion

            return result;
        }
    }
}
