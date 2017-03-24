namespace PhotoShare.Client.Core
{
    using Commands;
    using Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            var cmdName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            var result = string.Empty;

            // TODO resive on inicialization (ctor)
            var serviceUser = new UserService();
            var serviceTown = new TownService();


            switch (cmdName)
            {
                case "Exit":
                    var exit = new ExitCommand();
                    result = exit.Execute();
                    break;
                case "RegisterUser":
                    var user = new RegisterUserCommand(serviceUser);
                    result = user.Execute(commandParameters);
                    break;
                case "AddTown":
                    var town = new AddTownCommand(serviceTown);
                    result = town.Execute(commandParameters);
                    break;
                case "ModifyUser":
                    var userMod = new ModifyUserCommand(serviceUser, serviceTown);
                    result = userMod.Execute(commandParameters);
                    break;
            }

            return result;
        }
    }
}
