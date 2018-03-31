namespace Exercise_04_Froggy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp2
    {
        public static void Main()
        {

            string[] input = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            Lake<string> lake = new Lake<string>(input);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
