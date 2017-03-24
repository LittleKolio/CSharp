namespace PhotoShare.Client.Core.Commands
{
    using Service;
    using System;

    public class AddTownCommand
    {
        private TownService townService;

        public AddTownCommand(TownService townService)
        {
            this.townService = townService;
        }
        public string Execute(string[] data)
        {
            string name = data[0];
            string country = data[1];

            if (this.townService.IsExist(name))
            {
                throw new ArgumentException($"Town {name} already added!");
            }
            this.townService.AddTown(name, country);

            return $"Town {name} was added successfully!";
        }
    }
}
