namespace BashSoft_OOP.Interface
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; }

        IReadOnlyDictionary<string, IStudent> Students { get; }

        void EnrollStudent(IStudent student);
    }
}