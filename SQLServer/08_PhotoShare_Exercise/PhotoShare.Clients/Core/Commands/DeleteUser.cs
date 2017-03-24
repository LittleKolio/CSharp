namespace PhotoShare.Clients.Core.Commands
{
    using Service;
    using System;
    using System.Linq;

    public class DeleteUser : Command
    {
        private UserService service;
        public DeleteUser(string[] cmdParam) : base(cmdParam)
        {
            this.service = new UserService();
        }

        public override Command Create(string[] cmdParam)
        {
            return new DeleteUser(cmdParam);
        }

        public override string Execute()
        {
            //string[] cmdParam = { username }
            var username = cmdParam[0];

            if (!this.service.Exist(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            if (this.service.IsDeleted(username))
            {
                throw new InvalidOperationException($"User {username} is already deleted!");
            }
            this.service.Delete(username);

            return $"User {username} was deleted successfully!";
        }
    }
}
