namespace PhotoShare.Service
{
    using Data;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class UserService
    {
        public virtual void Add(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };
            using (var context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool Exist(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public virtual string AddPassword(string[] cmdParam)
        {
            //string[] cmdParam = { username, property, value }
            var username = cmdParam[0];
            var password = cmdParam[2];

            using (var context = new PhotoShareContext())
            {
                User user;

                try { user = context.Users.Single(u => u.Username == username); }
                catch { throw new ArgumentException($"User {username} not found!"); }

                user.Password = password;
                context.SaveChanges();
                return $"Password is {password}.";
            }
        }

        public virtual string AddBornTown(string[] cmdParam)
        {
            //string[] cmdParam = { username, property, value }
            var username = cmdParam[0];
            var borntown = cmdParam[2];

            using (var context = new PhotoShareContext())
            {
                User user;
                Town town;

                try { user = context.Users.Single(u => u.Username == username); }
                catch { throw new ArgumentException($"User {username} not found!"); }

                try { town = context.Towns.Single(t => t.Name == borntown); }
                catch { throw new ArgumentException($"Town {borntown} not found!"); }

                user.BornTown = town;
                context.SaveChanges();
                return $"BornTown is {borntown}.";
            }
        }

        public virtual string AddCurrentTown(string[] cmdParam)
        {
            //string[] cmdParam = { username, property, value }
            var username = cmdParam[0];
            var currenttown = cmdParam[2];

            using (var context = new PhotoShareContext())
            {
                User user;
                Town town;

                try { user = context.Users.Single(u => u.Username == username); }
                catch { throw new ArgumentException($"User {username} not found!"); }

                try { town = context.Towns.Single(t => t.Name == currenttown); }
                catch { throw new ArgumentException($"Town {currenttown} not found!"); }

                user.CurrentTown = town;
                context.SaveChanges();
                return $"CurrentTown is {currenttown}.";
            }
        }

        public bool IsDeleted(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users
                    .Single(u => u.Username == username)
                    .IsDeleted
                    .Value;
            }
        }

        public void Delete(string username)
        {
            using (var context = new PhotoShareContext())
            {
                var user = context.Users.Single(u => u.Username == username);
                user.IsDeleted = true;
                context.SaveChanges();
            }
        }
    }
}
