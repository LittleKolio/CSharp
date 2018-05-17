namespace BashSoft_OOP.IO.Interfaces
{
    using Models.Interfaces;
    using System.Collections.Generic;

    public interface IFormat
    {
        string CoursesToString(List<ICourse> courses, IStudent student);
        string StudentsToString(IList<IStudent> students, ICourse course);
        //string Box(string type, params string[] str);
    }
}
