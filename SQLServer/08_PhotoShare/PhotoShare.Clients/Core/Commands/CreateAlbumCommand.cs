namespace PhotoShare.Clients.Core.Commands
{
    using System;

    public class CreateAlbumCommand : Command
    {
        public CreateAlbumCommand(string[] cmdParam) : base(cmdParam)
        {
        }

        public override Command Create(string[] cmdParam)
        {
            return new CreateAlbumCommand(cmdParam);
        }

        public override string Execute()
        {
            //string[] cmdParam = { username, albumTitle, BgColor, tag1, tag2, ... tagN }
            return $"Album [Album] successfully created!";
        }
    }
}
