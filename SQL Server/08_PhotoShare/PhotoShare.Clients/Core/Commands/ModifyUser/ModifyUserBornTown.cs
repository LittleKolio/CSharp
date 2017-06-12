namespace PhotoShare.Clients.Core.Commands
{
    using Service;
    using System;
    using System.Collections.Generic;

    public class ModifyUserBornTown : Command
    {
        private UserService service;
        public ModifyUserBornTown(string[] cmdParam) : base(cmdParam)
        {
            this.service = new UserService();
        }

        public override Command Create(string[] cmdParam)
        {
            return new ModifyUserBornTown(cmdParam);
        }

        public override string Execute()
        {
            //string[] cmdParam = { username, property, value }
            return service.AddBornTown(this.cmdParam);
        }
    }
}
