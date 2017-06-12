namespace PhotoShare.Clients.Core.Commands
{
    using Service;
    using System;

    public class ModifyUserCommand : Command
    {
        private readonly CommandDispatcherModifyUser cmdDispModifyUser;
        public ModifyUserCommand(string[] cmdParam) : base(cmdParam)
        {
            this.cmdDispModifyUser = new CommandDispatcherModifyUser();
        }

        public override Command Create(string[] cmdParam)
        {
            //string[] cmdParam = { username, property, value }
            return new ModifyUserCommand(cmdParam);
        }

        public override string Execute()
        {
            //string[] cmdParam = { username, property, value }
            var username = this.cmdParam[0];
            var result = string.Empty;

            try
            {
                result = this.cmdDispModifyUser
                    .DispatchCommand(this.cmdParam)
                    .Execute();

                return $"User {username} " + result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
