namespace Defining_Classes_Exercises.Classes
{
    using System.Collections.Generic;
    using System.Linq;

    class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }
        public void AddMember(Person member)
        {
            this.people.Add(member);
        }
        public Person GetOldestMember()
        {
            return people
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }
        public List<Person> GetOlderThan30Members()
        {
            return people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}