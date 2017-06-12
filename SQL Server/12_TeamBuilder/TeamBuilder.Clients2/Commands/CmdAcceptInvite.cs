namespace TeamBuilder.Clients2.Commands
{
    using System;
    using TeamBuilder.Clients2.Utilities;

    public class CmdAcceptInvite
    {
        public string Execute(string[] cmdParam)
        {
            //0. <teamName>
            Check.CheckLength(1, cmdParam);
            var teamname = cmdParam[0];

            Authentication.Authorize();
            var user = Authentication.GetCurrentUser();

            if (!DBServices.IsTeamExisting(teamname))
            {
                throw new ArgumentException(string.Format(
                    Constants.ErrorMessages.TeamNotFound, 
                    teamname));
            }

            if (!DBServices.IsInviteExisting(
                teamname, user.Username))
            {
                throw new ArgumentException(string.Format(
                    Constants.ErrorMessages.InviteNotFound, teamname));
            }

            DBServices.AcceptInvite(
                teamname, user);

            return $"User {user.Username} joined team {teamname}!";
        }
    }
}
