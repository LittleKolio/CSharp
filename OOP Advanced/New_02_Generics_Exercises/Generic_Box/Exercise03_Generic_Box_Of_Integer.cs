namespace Generic_Box
{
    using System;

    public class Exercise03_Generic_Box_Of_Integer
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                Box<int> intBox = new Box<int>(num);
                Console.WriteLine(intBox);
            }
        }
    }
}
