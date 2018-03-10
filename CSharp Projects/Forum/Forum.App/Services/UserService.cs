namespace Forum.App.Services
{
    using Forum.Data;
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();
            bool userExists = forumData.Users
                .Any(u => u.Name == username && u.Password == password);

            return userExists;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();
            bool userExists = forumData.Users.Any(u => u.Name == username);

            if (!userExists)
            {
                int id = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(id, username, password, null);
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }
    }
}
