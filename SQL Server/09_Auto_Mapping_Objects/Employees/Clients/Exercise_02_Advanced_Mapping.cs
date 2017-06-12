namespace Employees.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using AutoMapper;
    using Models;
    using Models.Dto;

    class Exercise_02_Advanced_Mapping
    {
        static void Main()
        {
            MapperInitialize();

            using (var context = new EmployeesContext())
            {
                var managers = context.Employees.Where(e => e.Manager == null);
                var rerult = Mapper.Map<IEnumerable<ManagerDto>>(managers);
                foreach (var m in rerult)
                {
                    Console.WriteLine(m.ToString());
                }
            }
        }

        /*
        private static void PrintManagers(IEnumerable<ManagerDto> managers)
        {
            foreach (var m in managers)
            {
                Console.WriteLine(
                    $"{m.Firstname} {m.Lastname} | Employees: {m.SubCount}");
                foreach (var sub in m.Subordinates)
                {
                    Console.WriteLine($"  - {sub.Firstname} {sub.Lastname} {sub.Salary:F2}");
                }
            }
        }
        */

        private static void MapperInitialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                    .ForMember(
                        dto => dto.SubCount,
                        opt => opt.MapFrom(src => src.Subordinates.Count));
            });
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
