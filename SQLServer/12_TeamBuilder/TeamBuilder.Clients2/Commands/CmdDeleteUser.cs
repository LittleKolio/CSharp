namespace TeamBuilder.Clients2.Commands
{
    using TeamBuilder.Clients2.Utilities;

    public class CmdDeleteUser
    {
        public string Execute(string[] cmdParam)
        {
            Check.CheckLength(0, cmdParam);

            Authentication.Authorize();

            var user = Authentication.GetCurrentUser();
            DBServices.DeleteUser(user);

            Authentication.Logout();

            return $"User {user.Username} was deleted successfully!";
        }
    }
}
