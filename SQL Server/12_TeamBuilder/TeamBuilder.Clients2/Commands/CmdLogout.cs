namespace TeamBuilder.Clients2.Commands
{
    using TeamBuilder.Clients2.Utilities;

    public class CmdLogout
    {
        public string Execute(string[] cmdParam)
        {
            Check.CheckLength(0, cmdParam);
            Authentication.Authorize();
            var username = Authentication.GetCurrentUser().Username;
            Authentication.Logout();

            return $"User {username} successfully logged out!";
        }
    }
}
