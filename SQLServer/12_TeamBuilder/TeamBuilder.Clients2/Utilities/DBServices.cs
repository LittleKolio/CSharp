namespace TeamBuilder.Clients2.Utilities
{
    using Data;
    using System.Linq;
    using TeamBuilder.Models;

    public class DBServices
    {
        public static bool IsTeamExisting(string teamName)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Teams
                    .Any(t => t.Name == teamName);
            }
        }
        public static bool IsUserExisting(string username)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Users
                    .Any(t => t.Username == username);
            }
        }
        public static bool IsInviteExisting(string teamName, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Invitations
                    .Any(i => 
                        i.Team.Name == teamName && 
                        i.InvitedUserId == user.Id &&
                        i.IsActive);
            }
        }
        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Teams
                    .Any(t => 
                        t.Name == teamName && 
                        t.CreatorId == user.Id);
            }
        }
        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Events
                    .Any(e =>
                        e.Name == eventName &&
                        e.CreatorId == user.Id);
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
        public static bool IsEventExisting(string eventName)
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                return context.Events
                    .Any(e => e.Name == eventName);
            }
        }
    }
}
