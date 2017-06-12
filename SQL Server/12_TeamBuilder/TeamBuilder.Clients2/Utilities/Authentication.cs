namespace TeamBuilder.Clients2.Utilities
{
    using System;
    using TeamBuilder.Models;
    using Utilities;

    public class Authentication
    {
        public static User currentUser;

        public static void Login(User user) { currentUser = user; }

        public static void Logout()
        {
            Authorize();
            currentUser = null;
        }

        public static bool IsAuthorized() { return currentUser != null; }

        public static User GetCurrentUser()
        {
            Authorize();
            return currentUser;
        }

        public static void Authorize()
        {
            if (!IsAuthorized())
            {
                throw new InvalidOperationException(
                    Constants.ErrorMessages.LoginFirst);
            }
        }
    }
}
