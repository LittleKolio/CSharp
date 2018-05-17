namespace BashSoft_OOP.Repository
{
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Models;
    using Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;

    public class ProcessJsonFormat : IProcessJsonFormat
    {
        private IRepository repository;
        private IWriter consoleWriter;

        public ProcessJsonFormat(IRepository repository, IWriter consoleWriter)
        {
            this.repository = repository;
            this.consoleWriter = consoleWriter;
        }

        public void ReadCoursesFromFile(string coursesPath)
        {
            //string courses = File.ReadAllText(coursesPath);
            //this.coursesDto = JsonConvert.DeserializeObject<List<Course>>(courses);

            //JArray arr = JArray.Parse(File.ReadAllText(coursesPath));
            //foreach (JObject item in arr)
            //{
            //    this.consoleWriter.WriteOneLineMessage(item["course"].ToString());
            //}

            int prevCount = this.repository.Count;

            JsonTextReader reader = new JsonTextReader(File.OpenText(coursesPath));
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    JObject jObject = JObject.Load(reader);

                    CourseDto dto = jObject.ToObject<CourseDto>();

                    DtoMapper<Course, CourseDto> mapper = new DtoMapper<Course, CourseDto>();

                    Course course = mapper.Map(dto);

                    this.repository.AddCourse(course);
                }
            }

            this.IsCoursesImported(prevCount);
        }

        public void ReadStudentsFromFile(string studentsPath)
        {
            JsonTextReader reader = new JsonTextReader(File.OpenText(studentsPath));
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    JObject jObject = JObject.Load(reader);

                    StudentDto dto = jObject.ToObject<StudentDto>();

                    DtoMapper<Student, StudentDto> mapper = new DtoMapper<Student, StudentDto>();

                    Student student = mapper.Map(dto);

                    ICourse course = this.repository.GetCourse(dto.Course);

                    student.EnrollInCourse(course);

                    student.AddTestScoresByCourse(dto.Course, dto.Scores);

                    course.EnrollStudent(student);
                }
            }

            this.consoleWriter.WriteOneLineMessage("Students imported.");
        }

        private void IsCoursesImported(int prevCount)
        {
            if (this.repository.Count > prevCount)
            {
                this.consoleWriter.WriteOneLineMessage("Courses imported.");
            }
            else
            {
                this.consoleWriter.WriteOneLineMessage("Nothing imported!");
            }
        }
    }
}
