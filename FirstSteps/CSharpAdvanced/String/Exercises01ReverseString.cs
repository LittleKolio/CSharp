using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Exercises01ReverseString
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stopwatch watch = new Stopwatch();


            //watch.Start();
            //string result = new string(input.Reverse().ToArray());
            //watch.Stop();
            //Console.WriteLine(result);
            //Console.WriteLine(watch.Elapsed);


            //watch.Start();
            //StringBuilder strBuReverse = new StringBuilder();
            //for (int i = input.Length - 1; i >= 0; i--)
            //{
            //    strBuReverse.Append(input[i]);
            //}
            //watch.Stop();
            //Console.WriteLine(strBuReverse);
            //Console.WriteLine(watch.Elapsed);


            //watch.Start();
            //char[] arrfromInput = input.ToCharArray();
            //Array.Reverse(arrfromInput);
            //string toPrint = string.Join("", arrfromInput);
            //watch.Stop();
            //Console.WriteLine(toPrint);
            //Console.WriteLine(watch.Elapsed);


            watch.Start();
            Stack<char> stackfromInput = new Stack<char>(input);
            while (stackfromInput.Count != 0)
            {
                Console.Write(stackfromInput.Pop());
            }
            Console.WriteLine();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }
    }
}
