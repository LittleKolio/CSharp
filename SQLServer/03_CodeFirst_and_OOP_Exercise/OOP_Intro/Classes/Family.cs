namespace OOP_Intro.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Family
    {
        private List<Person> list;

        public Family()
        {
            this.list = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.list.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldest = this.list[0];
            foreach (var element in this.list)
            {
                if (element.Age > oldest.Age) { oldest = element; }
            }
            return oldest;
            //return this.list.OrderByDescending(e => e.Age).FirstOrDefault();
        }
    }
}
