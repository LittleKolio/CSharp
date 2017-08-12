namespace SOLID_Exercises.Exercises_01.Interfaces
{
    using SOLID_Exercises.Exercises_01.Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportType Type { get; }

        void Append(
            string dateTime, 
            string messageType, 
            string message);
    }
}
