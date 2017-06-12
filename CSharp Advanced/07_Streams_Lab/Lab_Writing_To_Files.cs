using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Lab
{
    class Lab_Writing_To_Files
    {
        static void Main()
        {
            string text = "using System.Threading.Tasks";
            FileStream fileStream = new FileStream(
                "../../Files/log.txt", FileMode.Create);

            // using or try-finally

            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                fileStream.Write(buffer, 0, buffer.Length);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
