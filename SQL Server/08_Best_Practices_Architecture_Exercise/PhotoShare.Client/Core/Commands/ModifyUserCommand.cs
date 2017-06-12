namespace PhotoShare.Client.Core.Commands
{
    using Service;
    using System;

    public class ModifyUserCommand
    {
        private UserService serviceUser;
        private TownService serviceTown;
        public ModifyUserCommand(UserService serviceUser, TownService serviceTown)
        {
            this.serviceUser = serviceUser;
            this.serviceTown = serviceTown;
        }
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string username = data[0];
            string property = data[1];
            string propVal = data[2];

            var user = this.serviceUser.GetUser(username);
            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }
            switch (property)
            {
                case "Password":
                    //TODO validation
                    user.Password = propVal;
                    break;
                case "BornTown":
                    var townBorn = this.serviceTown.GetTown(propVal);
                    if (townBorn == null)
                    {
                        throw new ArgumentException($"Town {propVal} not found!");
                    }
                    user.BornTown = townBorn;
                    break;
                case "CurrentTown":
                    var townCurr = this.serviceTown.GetTown(propVal);
                    if (townCurr == null)
                    {
                        throw new ArgumentException($"Town {propVal} not found!");
                    }
                    user.CurrentTown = townCurr;
                    break;
                default: throw new ArgumentException($"Property {property} not supported!");
            }
            this.serviceUser.UpdateUser(user);
            return $"User {username} {property} is {propVal}.";
        }
    }
}
