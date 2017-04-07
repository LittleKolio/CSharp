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

            Authentication.Authorize();
            var teamname = cmdParam[0];

            if (!DBServices.IsTeamExisting(teamname))
            {
                throw new ArgumentException(string.Format(
                    Constants.ErrorMessages.TeamNotFound, 
                    teamname));
            }

            return $"User [username] joined team [teamName]!";
        }
    }
}
