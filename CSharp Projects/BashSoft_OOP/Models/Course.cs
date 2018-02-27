namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private string name;
        private Dictionary<string, Student> studentByName;

        public string Name
        {
            get { return this.name; }
            set
            {
                //if (string.IsNullOrEmpty(value))
                //{
                //    throw new ArgumentNullException();
                //}
                this.name = value;
            }
        }

    }
}
