namespace BashSoft_OOP.Repository
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class JsonRepository
    {
        public class CourseDto
        {
            public CourseDto(string name)
            {
                this.Name = name;
            }

            //private string name;
            public string Name { get; }
        }

        public class StudentDto
        {
            [JsonProperty("student")]
            public string Name { get; set; }
            public string Course { get; set; }
            public List<int> Scores { get; set; }
        }

        public JsonRepository()
        {
            this.coursesDto = new List<CourseDto>();
            this.studentsDto = new List<StudentDto>();
        }

        private List<CourseDto> coursesDto;
        private List<StudentDto> studentsDto;

        public List<CourseDto> CoursesDto => this.coursesDto;
        public List<StudentDto> StudentsDto => this.studentsDto;

        public void ReadCourses(string coursesPath)
        {
            string courses = File.ReadAllText(coursesPath);

            this.coursesDto = JsonConvert.DeserializeObject<List<CourseDto>>(courses);
        }

        public void ReadStudents(string studentsPath)
        {
            string students = File.ReadAllText(studentsPath);

            this.studentsDto = JsonConvert.DeserializeObject<List<StudentDto>>(students);
        }
    }
}
