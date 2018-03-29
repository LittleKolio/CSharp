namespace Exercise_06_Strategy_Pattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private SortedSet<Person> sortedByName;
        private SortedSet<Person> sortedByAge;

        public Engine()
        {
            this.sortedByName = new SortedSet<Person>(new NameComparer());
            this.sortedByAge = new SortedSet<Person>(new AgeComparer());
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
                    Console.WriteLine("Not Integer");
                }

                try
                {
                    this.sortedByName.Add(new Person(name, age));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    this.sortedByAge.Add(new Person(name, age));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            this.Print(this.sortedByName);
            this.Print(this.sortedByAge);
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
