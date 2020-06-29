using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore062020.Models;

namespace WebStore062020.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> _Employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Age = 23,
                Birthday = "20.10.1997",
                SurName = "Гикбрейнс",
                FirstName = "Павел",
                SecondName = "Викторович"
            },
            new Employee
            {
                Id = 2,
                Age = 33,
                Birthday = "02.04.1987",
                SurName = "Зайцев",
                FirstName = "Александр",
                SecondName = "Сергеевич"
            },
            new Employee
            {
                Id = 3,
                Age = 43,
                Birthday = "15.01.1977",
                SurName = "Ловчев",
                FirstName = "Владимир",
                SecondName = "Алексеевич"
            },

        };

        public IActionResult Index() => View(_Employees);
  

        public IActionResult Details(int id)
        {
            var employee = _Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }
    }
}