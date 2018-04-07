namespace Exercise_02_Extended_Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PeopleDatabase
    {
        private const int capacity = 16;

        private IList<IPerson> people;

        public PeopleDatabase()
        {
            this.people = new List<IPerson>();
        }

        public PeopleDatabase(params IPerson[] people) : this()
        {
            this.FillArray(people);
        }

        public int Count => this.people.Count;

        private void FillArray(params IPerson[] people)
        {
            if (people.Length != capacity)
            {
                throw new InvalidOperationException(
                    $"Capacity is not {capacity}!");
            }

            for (int i = 0; i < people.Length; i++)
            {
                this.Add(people[i]);
            }
        }

        public void Add(IPerson person)
        {
            if (this.Count == capacity)
            {
                throw new InvalidOperationException(
                    $"Capacity limit has been reached!");
            }

            try
            {
                this.FindById(person.Id);
                this.FindByUsername(person.Username);
            }
            catch (InvalidOperationException)
            {
                this.people.Add(person);
            }
        }

        public void Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(
                    $"There is no people!");
            }

            this.people.RemoveAt(this.Count - 1);
        }

        public IPerson[] Fetch()
        {
            return this.people.ToArray();
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentException(
                    "Id cannot be negative!");
            }

            IPerson person = this.people.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new InvalidOperationException(
                    $"No user found with id:{id}");
            }

            return person;
        }

        public IPerson FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException(
                    "Username is empty!");
            }

            IPerson person = this.people.FirstOrDefault(p => p.Username == username);

            if (person == null)
            {
                throw new InvalidOperationException(
                    $"No user found with name:{username}");
            }

            return person;
        }
    }
}
