namespace PhotoShare.Service
{
    using Data;
    using PhotoShare.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class UserService
    {
        public virtual void Add(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };
            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool IsTaken(string username)
        {
            using (var cxt = new PhotoShareContext())
            {
                return cxt.Users.Any(u => u.Username == username);
            }
        }

        public User GetUser(string name)
        {
            using (var cxt = new PhotoShareContext())
            {
                return cxt.Users.SingleOrDefault(u => u.Username == name);
            }
        }

        public void UpdateUser(User user)
        {
            using (var cxt = new PhotoShareContext())
            {
                cxt.Entry(user).State = EntityState.Modified;
                cxt.SaveChanges();
            }
        }
    }
}
