namespace EFSingleton
{
    using System;

    public class ChildOne : Something
    {
        public override void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
