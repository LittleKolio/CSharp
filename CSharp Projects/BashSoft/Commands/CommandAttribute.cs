namespace BashSoft.Commands
{
    using System;

    public class CommandAttribute : Attribute
    {
        public CommandAttribute(string input)
        {
            this.Input = input;
        }

        public string Input { get; set; }
    }
}
