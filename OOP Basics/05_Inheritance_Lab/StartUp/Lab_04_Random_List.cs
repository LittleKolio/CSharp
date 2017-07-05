namespace Inheritance_Lab.StartUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_04_Random_List
    {
        static void Main()
        {
            RandomList rl = new RandomList();
            rl.Add("1");
            rl.Add("2");
            rl.Add("3");
            rl.Add("4");
            rl.Add("5");

            foreach (string item in rl)
            {
                Console.WriteLine(item);
            }
        }
    }
}
