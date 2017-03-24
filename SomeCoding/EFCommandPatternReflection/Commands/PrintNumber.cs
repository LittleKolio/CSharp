namespace EFCommandPatternReflection
{
    using System;

    public class PrintNumber : Command
    {
        public PrintNumber(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new PrintNumber(data);
        }

        public override void Execute()
        {
            Console.WriteLine(this.data.MyNum);
        }
    }
}
