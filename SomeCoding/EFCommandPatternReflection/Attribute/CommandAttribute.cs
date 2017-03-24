namespace EFCommandPatternReflection
{
    using System;

    // [Command] = [CommandAttribute]
    public class CommandAttribute : Attribute
    {
        public string commandStr;
        public CommandAttribute(string commandStr)
        {
            this.commandStr = commandStr;
        }
    }
}
