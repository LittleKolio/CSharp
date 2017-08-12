namespace SOLID_Exercises.Exercises_01.Interfaces
{
    using Enums;

    public interface IAppender
    {
        int Count { get; }
        ILayout Layout { get; }
        ReportType Type { get; set; }

        void Append(
            string dateTime, 
            string messageType, 
            string message);
    }
}
