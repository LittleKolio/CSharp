public class Box<T>
{
    public T Value { get; private set; }
    public Box(T value)
    {
        this.Value = value;
    }

    public override string ToString()
    {
        //return $"{this.Value.GetType().FullName}: {this.Value}";
        return $"{typeof(T).FullName}: {this.Value}";
    }
}