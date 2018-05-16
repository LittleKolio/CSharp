namespace BashSoft_OOP.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class StudentDto
    {
        [JsonProperty("student")]
        public string Name { get; set; }

        public string Course { get; set; }

        public int[] Scores { get; set; }
    }
}
