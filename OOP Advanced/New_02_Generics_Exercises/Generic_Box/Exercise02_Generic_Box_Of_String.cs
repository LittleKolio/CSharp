namespace Generic_Box
{
    using System;

    public class Exercise02_Generic_Box_Of_String
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string str = Console.ReadLine();
                Box<string> stringBox = new Box<string>(str);
                Console.WriteLine(stringBox);
            }
        }
    }
}
