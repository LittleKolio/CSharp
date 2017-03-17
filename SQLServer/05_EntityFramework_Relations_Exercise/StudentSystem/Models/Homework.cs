namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        public int Id { get; set; }

        [NotMapped]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }

    public enum ContentType
    {
        application,
        pdf,
        zip
    }
}
