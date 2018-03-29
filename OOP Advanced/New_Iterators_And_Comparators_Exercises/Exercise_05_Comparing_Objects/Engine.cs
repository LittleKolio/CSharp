namespace Exercise_05_Comparing_Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private IList<Person> collection;

        public Engine()
        {
            this.collection = new List<Person>();
        }

        public void Run()
        {
            string input;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] tokens = this.SplitInput(input, ", ");
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                try
                {
                    this.collection.Add(
                        new Person(name, age, town));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            int equal = this.Match(index);

            this.Print(equal);
        }

        private int Match(int index)
        {
            int equal = 0;
            Person person = this.collection[index];
            for (int i = 0; i < this.collection.Count; i++)
            {
                int match = person.CompareTo(this.collection[i]);

                if (match == 0)
                {
                    equal++;
                }
            }

            return equal;
        }

        private void Print(int equal)
        {
            if (equal == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine("{0} {1} {2}",
                    equal, this.collection.Count - equal, this.collection.Count);
            }
        }

        private string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
