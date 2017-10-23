namespace BashSoft.Commands
{
    using System;

    //[AttributeUsage(AttributeTargets.Class)]
    public class CmdAttribute : Attribute
    {
        //public CommandAttribute(CommandCode keyCode)
        //{
        //    this.KeyCode = keyCode;
        //}

        //public CommandCode KeyCode { get; set; }


        public CmdAttribute(string input)
        {
            this.Input= input;
        }

        public string Input { get; set; }
    }
}
