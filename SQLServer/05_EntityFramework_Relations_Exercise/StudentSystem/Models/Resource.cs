namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType TypeOfResource { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }

    public enum ResourceType
    {
        video,
        presentation,
        document,
        other
    }
}
