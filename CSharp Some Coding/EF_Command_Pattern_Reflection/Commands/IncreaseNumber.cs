namespace EFCommandPatternReflection
{
    using System;

    public class IncreaseNumber : Command
    {
        public IncreaseNumber(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new IncreaseNumber(data);
        }

        public override void Execute()
        {
            this.data.MyNum++;
        }
    }
}
