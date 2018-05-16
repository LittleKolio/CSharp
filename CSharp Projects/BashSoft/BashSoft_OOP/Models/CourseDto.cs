namespace BashSoft_OOP.Models
{
    using Newtonsoft.Json;

    public class CourseDto
    {
        [JsonProperty("course")]
        public string Name { get; set; }

        [JsonProperty("exams")]
        public int NumberOfExams { get; set; }
    }
}
