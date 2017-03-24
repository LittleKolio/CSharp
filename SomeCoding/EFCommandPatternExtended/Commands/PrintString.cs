namespace EFCommandPatternExtended
{
    using System;

    public class PrintString : Command
    {
        public PrintString(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new PrintString(data);
        }

        public override void Execute()
        {
            Console.WriteLine(this.data.MyStr);
        }
    }
}
