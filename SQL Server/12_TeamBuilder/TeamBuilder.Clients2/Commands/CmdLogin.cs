namespace TeamBuilder.Clients2.Commands
{
    using System;
    using TeamBuilder.Clients2.Utilities;

    public class CmdLogin
    {
        public string Execute(string[] cmdParam)
        {
            //0. <username>
            //1. <password>

            if (Authentication.currentUser != null)
            {
                throw new InvalidOperationException(
                    Constants.ErrorMessages.LogoutFirst);
            }

            Check.CheckLength(2, cmdParam);

            var username = cmdParam[0];
            var password = cmdParam[1];

            var user = DBServices.GetUserByCredentials(username, password);
            if (user == null)
            {
                throw new ArgumentException(
                    Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            Authentication.Login(user);

            return $"User {username} successfully logged in!";
        }
    }
}
