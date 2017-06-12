namespace PhotoShare.Clients.Core.Commands
{
    using Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ModifyUserPassword : Command
    {
        private UserService service;
        public ModifyUserPassword(string[] cmdParam) : base(cmdParam)
        {
            this.service = new UserService();
        }

        public override Command Create(string[] cmdParam)
        {
            return new ModifyUserPassword(cmdParam);
        }

        public override string Execute()
        {
            //string[] cmdParam = { username, property, value }
            var password = this.cmdParam[2];

            if (password.Any(char.IsLower) && 
                password.Any(char.IsDigit))
            {
                return this.service.AddPassword(this.cmdParam);
            }

            throw new ArgumentException($"Invalid Password");
        }
    }
}
