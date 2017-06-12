namespace Employees.Models.Dto
{
    using System;

    public class EmployeeDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Salary { get; set; }
        public string ManagerLastname { get; set; }

        public string ToToString()
        {
            return $"  - {this.Firstname} {this.Lastname} {this.Salary:F2}";
        }
        public override string ToString()
        {
            return $"{this.Firstname} {this.Lastname} {this.Salary:F2}" + 
                $" - Manager: {this.ManagerLastname ?? "[no manager]"}";
        }
    }
}
