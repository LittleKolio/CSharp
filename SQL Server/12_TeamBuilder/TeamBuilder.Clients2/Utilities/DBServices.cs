namespace TeamBuilder.Clients2.Utilities
{
    using Data;
    using System.Linq;
    using TeamBuilder.Models;
    using System;

    public class DBServices
    {
        #region User
        public static User GetUser(string username)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Users
                    .FirstOrDefault(t => 
                        t.Username == username &&
                        t.IsDeleted == false);
            }
        }

        public static bool IsUserExisting(string username)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Users
                    .Any(t => 
                        t.Username == username &&
                        t.IsDeleted == false);
            }
        }

        public static void DisbandTeam(string teamname)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                var team = context.Teams.First(t => t.Name == teamname);
                context.Teams.Remove(team);
                context.SaveChanges();
            }
        }

        public static void AcceptInvite(string teamname, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                context.Users.Attach(user);
                var team = context.Teams.First(t => t.Name == teamname);
                user.InTeams.Add(team);

                var invitation = context.Invitations
                    .First(i => 
                        i.InvitedUserId == user.Id &&
                        i.TeamId == team.Id &&
                        i.IsActive);
                invitation.IsActive = false;

                context.SaveChanges();
            }
        }

        public static User GetUserByCredentials(string username, string password)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Users
                    .FirstOrDefault(t => 
                        t.Username == username && 
                        t.Password == password &&
                        t.IsDeleted == false);
            }
        }
        public static void DeleteUser(User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                context.Users.Attach(user);
                user.IsDeleted = true;
                context.SaveChanges();
            }
        }
        public static bool IsUserInTeam(string teamname, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Teams.Any(t =>
                    t.Name == teamname &&
                    (t.Users.Any(u => u.Id == user.Id) || t.CreatorId == user.Id));
            }
        }
        public static void AddCurrentUserToTeam(string teamname, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                context.Users.Attach(user);
                var team = context.Teams.First(t => t.Name == teamname);
                team.Users.Add(user);
                context.Invitations
                    .First(i => 
                        i.TeamId == team.Id && 
                        i.InvitedUserId == user.Id)
                    .IsActive = false;
                context.SaveChanges();
            }
        }
        #endregion

        #region Team
        public static bool IsTeamExisting(string teamname)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Teams
                    .Any(t => t.Name == teamname);
            }
        }
        public static bool IsUserCreatorOfTeam(string teamname, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Teams
                    .Any(t => 
                        t.Name == teamname && 
                        t.CreatorId == user.Id);
            }
        }
        public static bool IsMemberOfTeam(string teamName, string username)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Teams
                    .Any(t =>
                        t.Name == teamName &&
                        t.Users.Any(u => u.Username == username));
            }
        }
        public static void CreateTeam(Team team, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                context.Users.Attach(user);
                team.Creator = user;
                context.Teams.Add(team);
                context.SaveChanges();
            }
        }
        #endregion

        #region Event
        public static bool IsEventExisting(string eventname)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Events
                    .Any(e => e.Name == eventname);
            }
        }
        public static bool IsUserCreatorOfEvent(string eventname, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Events
                    .Any(e =>
                        e.Name == eventname &&
                        e.CreatorId == user.Id);
            }
        }
        public static void CreateEvent(Event newEvent, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                context.Users.Attach(user);
                newEvent.Creator = user;
                context.Events.Add(newEvent);
                context.SaveChanges();
            }
        }
        #endregion

        #region Invitation
        public static bool IsInviteExisting(string teamname, string username)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                var getUserId = context.Users.First(u => u.Username == username).Id;
                return context.Invitations
                    .Any(i => 
                        i.Team.Name == teamname && 
                        i.InvitedUserId == getUserId &&
                        i.IsActive);
            }
        }
        public static void CreateInvitation(string teamname, string username)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                var team = context.Teams.First(t => t.Name == teamname);
                var user = context.Users.First(u => u.Username == username);
                context.Invitations.Add(new Invitation
                {
                    InvitedUser = user,
                    Team = team,
                    IsActive = true
                });
                context.SaveChanges();
            }
        }
        #endregion
    }
}
