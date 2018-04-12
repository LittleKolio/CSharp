namespace Exercise_01_Event_Implementation
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IDispatcher dis = new Dispatcher();
            IHandler han = new Handler();
            //INameChange nameChange = new NameChangeEventArgs();

            dis.NameChange += han.OnDispatcherNameChange;

            NameChangeEventHandler aa = delegate (object sender, INameChange a)
            {
                Console.WriteLine($"Dispatcher's name changed to {a.Name}.");
            };

            string input;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                dis.Name = input;
            }
        }
    }
}
