namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;
    using System;

    public class LogInController : IController, IReadUserInfoController
    {
        //private enum Command
        //{
        //    ReadUsername,
        //    ReadPassword,
        //    LogIn,
        //    Back
        //}

        public LogInController()
        {
            ResetLogin();
        }

        public string Username { get; private set; }
        private string Password { get; set; }
        private bool Error { get; set; }

        private void ResetLogin()
        {
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Error = false;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername: return MenuState.Login;
                case Command.ReadPassword: return MenuState.Login;
                case Command.LogIn:
                    {
                        bool loggedIn = UserService.TryLogInUser(this.Username, this.Password);
                        if (loggedIn)
                        {
                            return MenuState.SuccessfulLogIn;
                        }
                        this.Error = true;
                        return MenuState.Error;
                    }
                case Command.Back: return MenuState.Back;
            }

            //TODO
            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new LogInView(this.Error, this.Username, this.Password.Length);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }
    }
}
