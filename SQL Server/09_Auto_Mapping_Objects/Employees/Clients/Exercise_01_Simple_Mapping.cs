namespace Employees
{
    using AutoMapper;
    using Data;
    using Models;
    using Models.Dto;
    using System.Linq;

    class Exercise_01_Simple_Mapping
    {
        static void Main()
        {
            //var context = new EmployeesContext();
            //context.Database.Initialize(true);

            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());
            EmployeeDto empdto;

            using (var context = new EmployeesContext())
            {
                var emp = context.Employees.Find(1);

                empdto = Mapper.Map<EmployeeDto>(emp);

                //empdto = MapToDto(emp);

            }
            System.Console.WriteLine($"{empdto.Firstname} {empdto.Lastname}");
        }

        public static EmployeeDto MapToDto(Employee emp)
        {
            return new EmployeeDto
            {
                Firstname = emp.Firstname,
                Lastname = emp.Lastname,
                Salary = emp.Salary
            };
        }
    }
}
