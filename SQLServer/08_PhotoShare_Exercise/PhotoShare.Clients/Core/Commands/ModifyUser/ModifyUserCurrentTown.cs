namespace PhotoShare.Clients.Core.Commands
{
    using Service;
    using System;
    using System.Collections.Generic;

    public class ModifyUserCurrentTown : Command
    {
        private UserService service;
        public ModifyUserCurrentTown(string[] cmdParam) : base(cmdParam)
        {
            this.service = new UserService();
        }

        public override Command Create(string[] cmdParam)
        {
            return new ModifyUserCurrentTown(cmdParam);
        }

        public override string Execute()
        {
            //string[] cmdParam = { username, property, value }
            return service.AddCurrentTown(this.cmdParam);
        }
    }
}
