using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // if the properties names are different
            // Initialize the mapper
            //var config = new MapperConfiguration(cfg =>
            //        cfg.CreateMap<Employee, EmployeeDTO>()
            //        .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name))
            //        .ForMember(dest => dest.Dept, act => act.MapFrom(src => src.Department))
            //    );

            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Employee, EmployeeDTO>()
                );
            //Creating the source object
            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };
            //Using automapper
            var mapper = new Mapper(config);
            var empDTO = mapper.Map<EmployeeDTO>(emp);
            //OR
            //var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
            Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Address:" + empDTO.Address + ", Department:" + empDTO.Department);
            Console.ReadLine();
        }
    }
}
