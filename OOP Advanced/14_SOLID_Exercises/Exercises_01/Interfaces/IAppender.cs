namespace SOLID_Exercises.Exercises_01.Interfaces
{
    using SOLID_Exercises.Exercises_01.Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportType Type { get; set; }

        void Append(
            string dateTime, 
            string messageType, 
            string message);
    }
}
