namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Score
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string InternalScoreList { get; set; }

        public List<int> ScoreList
        {
            get
            {
                return this.InternalScoreList
                    .Split(';')
                    .Select(int.Parse)
                    .ToList();
            }
            set
            {
                this.InternalScoreList = String.Join(";", value);
            }
        }
    }
}
