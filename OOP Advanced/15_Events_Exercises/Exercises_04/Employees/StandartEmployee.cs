namespace Events_Exercises.Exercises_04
{
    public class StandartEmployee : Employee
    {
        private const int WorkHoursPerWeek = 40;
        public StandartEmployee(string name) 
            : base(name, WorkHoursPerWeek)
        {
        }
    }
}
