using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Entities;
using WebStore062020.ViewModels;

namespace WebStore062020.Infrastructure.Mapping
{
    public static class EmployeeMapper
    {
        public static EmployeesViewModel ToView(this Employee employee) => new EmployeesViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            SurName = employee.SurName,
            SecondName = employee.SecondName,
            Age = employee.Age,
            Birthday = employee.Birthday
        };

        public static IEnumerable<EmployeesViewModel> ToView(this IEnumerable<Employee> employees) => employees.Select(ToView);

        public static Employee FromView(this EmployeesViewModel Model) => new Employee
        {
            Id = Model.Id,
            SurName = Model.SurName,
            FirstName = Model.FirstName,
            SecondName = Model.SecondName,
            Age = Model.Age,
            Birthday = Model.Birthday
        };
    }
}
