namespace TeamBuilder.Clients2.Commands
{
    using Models;
    using System;
    using TeamBuilder.Clients2.Utilities;

    public class CmdCreateTeam
    {
        public string Execute(string[] cmdParam)
        {
            //0. <name>
            //1. <acronym>
            //2. <description>

            if (cmdParam.Length != 2 && cmdParam.Length != 3)
            {
                throw new ArgumentException();
            }

            var name = cmdParam[0];
            if (name.Length > 25)
            {
                throw new ArgumentException($"Team {name} out of range.");
            }
            if (DBServices.IsTeamExisting(name))
            {
                throw new ArgumentException(string.Format(
                    Constants.ErrorMessages.TeamExists,
                    name));
            }

            var acronym = cmdParam[1];
            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(
                    Constants.ErrorMessages.InvalidAcronym, 
                    acronym));
            }

            var description = cmdParam.Length == 3 ? cmdParam[2] : null;

            var team = new Team
            {
                Name = name,
                Acronym = acronym,
                Description = description
            };

            var user = Authentication.GetCurrentUser();
            DBServices.CreateTeam(team, user);

            return $"Team {name} successfully created!";
        }
    }
}
