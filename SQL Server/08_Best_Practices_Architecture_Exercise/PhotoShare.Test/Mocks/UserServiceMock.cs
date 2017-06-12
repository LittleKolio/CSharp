namespace PhotoShare.Test.Mocks
{
    using PhotoShare.Service;

    public class UserServiceMock : UserService
    {
        public override void Add(string username, string password, string email)
        {
            base.Add(username, password, email);
        }
    }
}
