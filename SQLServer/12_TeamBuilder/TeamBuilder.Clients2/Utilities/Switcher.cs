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
                case "test":
                    var test = new CmdTest();
                    result = test.Execute(cmdParam);
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
                    result = registerUser.Executer(cmdParam);
                    break;

                default: throw new NotSupportedException(
                  $"Command {cmd} not valid!");
            }

            return result;
        }
    }
}
