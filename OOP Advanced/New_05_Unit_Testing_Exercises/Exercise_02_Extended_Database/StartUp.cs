namespace Exercise_02_Extended_Database
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //FindById();

            FindById_NegativeId();
        }

        private static void FindById_NegativeId()
        {
            PeopleDatabase peopleDatabase = new PeopleDatabase();

            IPerson person = null;
            try
            {
                person = peopleDatabase.FindById(-1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(person);
        }

        private static void FindById()
        {
            int capacity = 16;
            Person[] people = new Person[capacity];

            int id = 0;
            Func<int, string> name = num => ((char)(97 + num)).ToString();

            for (int i = 0; i < capacity; i++)
            {
                id = i + 1;
                people[i] = new Person(i + 1, name(i));
            }
            PeopleDatabase peopleDatabase = new PeopleDatabase(people);

            Console.WriteLine(peopleDatabase.FindById(id));
        }
    }
}
