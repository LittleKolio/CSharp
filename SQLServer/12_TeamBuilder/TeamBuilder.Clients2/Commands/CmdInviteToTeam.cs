namespace TeamBuilder.Clients2.Commands
{
    using System;
    using TeamBuilder.Clients2.Utilities;

    public class CmdInviteToTeam
    {
        public string Execute(string[] cmdParam)
        {
            //0. <teamName>
            //1. <username>

            Check.CheckLength(2, cmdParam);

            Authentication.Authorize();

            var teamname = cmdParam[0];
            var username = cmdParam[1];

            if (!DBServices.IsTeamExisting(teamname) &&
                !DBServices.IsUserExisting(username))
            {
                throw new ArgumentException(
                    Constants.ErrorMessages.TeamOrUserNotExist);
            }

            if (DBServices.IsInviteExisting(teamname, username))
            {
                throw new ArgumentException(
                    Constants.ErrorMessages.InviteIsAlreadySent);
            }

            if (!DBServices.IsUserInTeam(
                teamname, Authentication.GetCurrentUser()))
            {
                throw new InvalidOperationException(
                    Constants.ErrorMessages.NotAllowed);
            }

            DBServices.CreateInvitation(teamname, username);

            var currentUser = Authentication.GetCurrentUser();
            if (currentUser.Username == username &&
                DBServices.IsUserCreatorOfTeam(teamname, currentUser))
            {
                DBServices.AddCurrentUserToTeam(teamname, currentUser);
            }

            return $"Team {teamname} invited {username}!";
        }
    }
}
