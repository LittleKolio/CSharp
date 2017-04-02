namespace PhotoShare.Clients.Core.Commands
{
    using Service;
    using System;

    public class RegisterUserCommand : Command
    {
        private UserService service;
        public RegisterUserCommand(string[] cmdParam)
            : base(cmdParam)
        {
            this.service = new UserService();
        }

        public override Command Create(string[] cmdParam)
        {
            return new RegisterUserCommand(cmdParam);
        }

        public override string Execute()
        {
            var username = this.cmdParam[0];
            var password = this.cmdParam[1];
            var repPass = this.cmdParam[2];
            var email = this.cmdParam[3];

            if (password != repPass)
            {
                throw new ArgumentException($"Passwords do not match!");
            }
            if (this.service.Exist(username))
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }
            this.service.Add(username, password, email);
            return $"User {username} was registered successfully!";
        }
    }
}
