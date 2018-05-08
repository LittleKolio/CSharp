using System.Collections.Generic;

namespace BashSoft_OOP.Interface
{
    public interface IFormat
    {
        string CoursesToString(List<ICourse> courses, IStudent student);
        string StudentsToString(IList<IStudent> students, ICourse course);
    }
}
