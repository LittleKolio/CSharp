namespace Generic_Box
{
    using System;

    public class Exercise01_Generic_Box
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Box<int> intBox = new Box<int>(input);
            Console.WriteLine(intBox);

            string str = Console.ReadLine();
            Box<string> stringBox = new Box<string>(str);
            Console.WriteLine(stringBox);
        }
    }
}
