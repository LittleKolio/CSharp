namespace BashSoft.Commands
{
    using System;

    //[AttributeUsage(AttributeTargets.Class)]
    public class CmdAttribute : Attribute
    {
        public CmdAttribute(CmdEnum keyCode)
        {
            this.KeyCode = keyCode;
        }

        public CmdEnum KeyCode { get; set; }
    }
}
