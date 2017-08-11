namespace SOLID_Exercises.Exercises_01.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(
            string dateTime, 
            string messageType, 
            string message);
    }
}
