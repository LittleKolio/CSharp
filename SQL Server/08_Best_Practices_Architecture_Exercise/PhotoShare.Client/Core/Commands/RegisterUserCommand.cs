namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Service;

    public class RegisterUserCommand
    {
        private readonly UserService service;
        public RegisterUserCommand(UserService service)
        {
            this.service = service;
        }
        public object UserService { get; private set; }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }
            if (this.service.IsTaken(username))
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }

            this.service.Add(username, password, email);

            return "User " + username + " was registered successfully!";
        }
    }
}
