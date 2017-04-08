namespace TeamBuilder.Clients2.Commands
{
    using System;
    using TeamBuilder.Clients2.Utilities;

    public class CmdDisband
    {
        public string Execute(string[] cmdParam)
        {
            //0. <teamName>
            Check.CheckLength(1, cmdParam);
            var teamname = cmdParam[0];

            Authentication.Authorize();

            if (!DBServices.IsTeamExisting(teamname))
            {
                throw new ArgumentException(string.Format(
                    Constants.ErrorMessages.TeamNotFound, teamname));
            }

            if (!DBServices.IsUserCreatorOfTeam(
                teamname, Authentication.GetCurrentUser()))
            {
                throw new InvalidOperationException(
                    Constants.ErrorMessages.NotAllowed);
            }

            DBServices.DisbandTeam(teamname);
            return $"{teamname} has disbanded!";
        }
    }
}
