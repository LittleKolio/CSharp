namespace BashSoft_OOP.Repository
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using Interface;
    using Newtonsoft.Json.Linq;

    public class JsonRepository
    {
        public class StudentDto
        {
            [JsonProperty("student")]
            public string Name { get; set; }
            public string Course { get; set; }
            public List<int> Scores { get; set; }
        }

        private IWriter consoleWriter;

        public JsonRepository(IWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
            this.coursesDto = new List<Course>();
            this.studentsDto = new List<StudentDto>();
        }

        private List<CourseDto> coursesDto;
        private List<StudentDto> studentsDto;

        public List<CourseDto> CoursesDto => this.coursesDto;
        public List<StudentDto> StudentsDto => this.studentsDto;

        public void ReadCourses(string coursesPath)
        {
            string courses = File.ReadAllText(coursesPath);
            this.coursesDto = JsonConvert.DeserializeObject<List<Course>>(courses);

            //JArray arr = JArray.Parse(File.ReadAllText(coursesPath));
            //foreach (JObject item in arr)
            //{
            //    this.consoleWriter.WriteOneLineMessage(item["course"].ToString());
            //}

            //JsonTextReader reader = new JsonTextReader(File.OpenText(coursesPath));
            //while (reader.Read())
            //{
            //    if (reader.Value != null)
            //    {
            //        this.consoleWriter.WriteOneLineMessage(string.Format("Token: {0}, Value: {1}", reader.TokenType, reader.Value));
            //    }
            //    else
            //    {
            //        this.consoleWriter.WriteOneLineMessage(string.Format("Token: {0}", reader.TokenType));
            //    }
            //}
        }

        public void ReadStudents(string studentsPath)
        {
            string students = File.ReadAllText(studentsPath);

            this.studentsDto = JsonConvert.DeserializeObject<List<StudentDto>>(students);
        }

        private void Settings()
        {
            JsonSerializerSettings settins = new JsonSerializerSettings
            {
                //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                //PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented
            };
        }
    }
}
