namespace Trash.Lab05_Streams
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Class1
    {
        public static void Main()
        {
            using (StreamReader stream = new StreamReader("text.txt"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}
