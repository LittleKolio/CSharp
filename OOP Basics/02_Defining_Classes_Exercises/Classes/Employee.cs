namespace Defining_Classes_Exercises.Classes
{
    class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private short age;

        public Employee(
            string name, 
            decimal salary, 
            string position, 
            string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;

            this.Email = "n/a";
            this.Age = -1;
        }

        public short Age
        {
            set { this.age = value; }
        }

        public string Email
        {
            set { this.email = value; }
        }

        public string Department
        {
            get { return this.department; }
        }

        public decimal Salary
        {
            get { return this.salary; }
        }

        public string EmployeeInfo()
        {
            return $"{this.name} {this.salary:F2} {this.email} {this.age}";
        }
    }
}
