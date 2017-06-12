namespace Employees.Models.Dto
{
    using System.Collections.Generic;
    using System.Text;

    public class ManagerDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<EmployeeDto> Subordinates { get; set; }
        public int SubCount { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"{this.Firstname} {this.Lastname} | Employees: {this.SubCount}");
            foreach (var sub in this.Subordinates)
            {
                result.AppendLine(sub.ToToString());
            }
            return result.ToString().Trim();
        }
    }
}
