namespace PhotoShare.Clients.Core.Commands
{
    using PhotoShare.Service;
    using System;

    public class AddTownCommand : Command
    {
        private TownService service;
        public AddTownCommand(string[] cmdParam) : base(cmdParam)
        {
            this.service = new TownService();
        }

        public override Command Create(string[] cmdParam)
        {
            return new AddTownCommand(cmdParam);
        }

        public override string Execute()
        {
            string townname = this.cmdParam[0];
            string country = this.cmdParam[1];

            if (this.service.Exist(townname))
            {
                throw new ArgumentException($"Town {townname} already added!");
            }
            this.service.Add(townname, country);
            return $"Town {townname} was added successfully!";
        }
    }
}
