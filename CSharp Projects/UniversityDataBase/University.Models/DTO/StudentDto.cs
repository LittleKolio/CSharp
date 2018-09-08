namespace University.Models.DTO
{
    using System.Collections.Generic;

    public class StudentDto
    {
        public string StudentName { get; set; }
        public virtual ICollection<CourseDto> Courses { get; set; }
    }
}
