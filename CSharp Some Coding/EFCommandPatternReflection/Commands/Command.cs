namespace EFCommandPatternReflection
{
    public abstract class Command
    {
        protected MyData data;
        public Command(MyData data)
        {
            this.data = data;
        }
        public abstract void Execute();
        public abstract Command Create(MyData data);
    }
}
