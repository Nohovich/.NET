using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperIgnoreProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapper = InitializeAutomapper();
            Employee employee = new Employee()
            {
                ID = 101,
                Name = "James",
                Address = "Mumbai"
            };
            var empDTO = mapper.Map<Employee, EmployeeDTO>(employee);
            Console.WriteLine("After Mapping : Employee");
            Console.WriteLine("ID : " + employee.ID + ", Name : " + employee.Name + ", Address : " + employee.Address + ", Email : " + employee.Email);
            Console.WriteLine();
            Console.WriteLine("After Mapping : EmployeeDTO");
            Console.WriteLine("ID : " + empDTO.ID + ", Name : " + empDTO.Name + ", Address : " + empDTO.Address + ", Email : " + empDTO.Email);
            Console.ReadLine();
        }
        static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>()
                .IgnoreNoMap(); ;
            });
            var mapper = new Mapper(config);
            return mapper;
        }
    }

    public class NoMapAttribute : System.Attribute
    {
    }
    public static class IgnoreNoMapExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            foreach (var property in sourceType.GetProperties())
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                NoMapAttribute attribute = (NoMapAttribute)descriptor.Attributes[typeof(NoMapAttribute)];
                if (attribute != null)
                    expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }
    }

}
