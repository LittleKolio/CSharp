namespace University.Models
{
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Scores = new HashSet<Score>();
            this.IsDeleted = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
    }
}
