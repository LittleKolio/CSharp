using TeamBuilder.Clients2.Utilities;

namespace TeamBuilder.Clients2.Commands
{
    public class CmdTest
    {
        public string Execute(string[] cmdParam)
        {
            var username = cmdParam[0];
            var user = DBServices.GetUser(username);
            string result = string.Empty;
            if (user == null)
            {
                result = "breee NULL";
            }
            else
            {
                result = user.Username;
            }

            return result;
        }
    }
}
