namespace Employees.Clients
{
    using AutoMapper;
    using Models;
    using Models.Dto;
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;

    public class Exercise_03_Projection
    {
        static void Main()
        {
            MapperInitialize();
            using (var context = new EmployeesContext())
            {
                var emps = context.Employees
                    .Where(e => e.Birthday.Value.Year < 1990)
                    .OrderByDescending(e => e.Salary)
                    .ProjectTo<EmployeeDto>();
                foreach (var e in emps)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private static void MapperInitialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dto => dto.ManagerLastname, 
                        opt => opt.MapFrom(e => e.Manager.Lastname));
            });
        }
    }
}
