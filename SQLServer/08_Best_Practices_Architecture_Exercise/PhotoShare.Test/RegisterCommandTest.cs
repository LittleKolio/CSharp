namespace PhotoShare.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Client.Core.Commands;
    using Mocks;

    [TestClass]
    public class RegisterCommandTest
    {
        [TestMethod]
        public void Register_NewUser()
        {
            string[] param = new string[] 
            {
                "admin",
                "abc123",
                "abc123",
                "user@softuni.bg"
            };
            var cmd = new RegisterUserCommand(new UserServiceMock());
            var result = cmd.Execute(param);

            Assert.AreEqual($"User {param[0]} was registered successfully!", result);
        }
    }
}
