using System;

namespace EFServiceLocator
{
    public class ChildOne : Something
    {
        public override void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
