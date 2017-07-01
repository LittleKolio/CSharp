namespace Defining_Classes_Exercises.Classes
{
    using System;

    class DateModifier
    {
        private DateTime dateOne;
        private DateTime dateTwo;
        public DateModifier(string dateOne, string dateTwo)
        {
            this.dateOne = Parser(dateOne);
            this.dateTwo = Parser(dateTwo);
        }

        private DateTime Parser(string date)
        {
            return DateTime.ParseExact(date, "yyyy MM dd", null);
        }

        public int Difference
        {
            get
            {
                return Math.Abs(
                    (this.dateTwo - this.dateOne).Days);
            }
        }
    }
}
