using PhotoShare.Client.Utilities;
using PhotoShare.Service;
using System;
using System.Text.RegularExpressions;

namespace PhotoShare.Clients.Core.Commands
{
    public class AddTagCommand : Command
    {
        private TagService servce;
        public AddTagCommand(string[] cmdParam) : base(cmdParam)
        {
            this.servce = new TagService();
        }

        public override Command Create(string[] cmdParam)
        {
            return new AddTagCommand(cmdParam);
        }

        public override string Execute()
        {
            //string[] cmdParam = { tagname, ... }
            var tagname = string.Join("",this.cmdParam)
                .ValidateOrTransform();

            if (servce.Exist(tagname))
            {
                throw new ArgumentException($"Tag {tagname} exists!");
            }

            servce.AddTag(tagname);
            return $"Tag {tagname} was added successfully!";
        }
    }
}
