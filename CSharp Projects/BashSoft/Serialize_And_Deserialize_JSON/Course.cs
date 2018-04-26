using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable()]
public class Course : ISerializable
{
    //public const int numberOfTasksOnExam = 5;
    //public const int maxScoreOnExam = 100;

    private string name;
    private Dictionary<string, Student> students;

    public Course(string name)
    {
        this.Name = name;
        this.students = new Dictionary<string, Student>();
    }

    public Course(SerializationInfo info, StreamingContext context)
    {
        this.students = new Dictionary<string, Student>();
        this.Name = (string)info.GetValue("CourseName", typeof(string));
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.name = value;
        }
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("CourseName", this.Name);
    }

    //public void EnrollStudent(Student student)
    //{
    //    if (students.ContainsKey(student.Name))
    //    {
    //        OutputWriter.WriteException(string.Format(
    //            ExceptionMessages.data_Student_InCourse, student.Name, this.Name));
    //        return;
    //    }
    //    this.students.Add(student.Name, student);
    //}
}