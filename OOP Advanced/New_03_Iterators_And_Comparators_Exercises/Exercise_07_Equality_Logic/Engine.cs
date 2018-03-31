namespace Exercise_07_Equality_Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private SortedSet<Person> sortedSet;
        private HashSet<Person> hashSet;

        public Engine()
        {
            this.sortedSet = new SortedSet<Person>();
            this.hashSet = new HashSet<Person>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {

                string[] tokens = this.SplitInput(Console.ReadLine(), " ");
                string name = tokens[0];
                int age;
                if (!int.TryParse(tokens[1], out age))
                {
                    Console.WriteLine("Not Integer!");
                }

                try
                {
                    this.sortedSet.Add(new Person(name, age));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    this.hashSet.Add(new Person(name, age));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(this.sortedSet.Count);
            Console.WriteLine(this.hashSet.Count);
        }

        private void Print(IEnumerable<Person> list)
        {
            foreach (Person person in list)
            {
                Console.WriteLine(person);
            }
        }

        private string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
