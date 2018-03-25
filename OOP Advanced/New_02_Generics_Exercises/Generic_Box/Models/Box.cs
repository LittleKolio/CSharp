namespace Generic_Box
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {this.Value}";
        }
    }
}