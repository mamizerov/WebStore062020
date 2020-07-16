using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore062020.Infrastructure.Interfaces;
using WebStore062020.ViewModels;
using WebStore.Domain.Entities;
using WebStore062020.Infrastructure.Mapping;
using Microsoft.AspNetCore.Authorization;
using WebStore.Domain.Entities.Identity;

namespace WebStore062020.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

        //[Route("All")]
        public IActionResult Index() => View(_EmployeesData.Get().ToView());
        /*
        public IActionResult Index() => View(_EmployeesData.Get().Select(employee => new EmployeesViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            SecondName = employee.SecondName,
            SurName = employee.SurName,
            Birthday = employee.Birthday,
            Age = employee.Age
        }));
        */


        public IActionResult Details(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(employee.ToView());
            /*
            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                SecondName = employee.SecondName,
                SurName = employee.SurName,
                Birthday = employee.Birthday,
                Age = employee.Age
            });
            */
        }

            #region Edit

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new EmployeesViewModel());

            if (id < 0)
                return BadRequest();

            var employee = _EmployeesData.GetById((int)id);
            if (employee is null)
                return NotFound();

            return View(employee.ToView());
            /*
            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                SecondName = employee.SecondName,
                SurName = employee.SurName,
                Birthday = employee.Birthday,
                Age = employee.Age
            });
            */
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(EmployeesViewModel Model)
        {
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));

            if (Model.Age < 18 || Model.Age > 75)
                ModelState.AddModelError(nameof(Employee.Age), "Возраст должен быть всё же в пределах от 18 до 75");

            if (!ModelState.IsValid)
                return View(Model);

            /*
            var employee = new Employee
            {
                Id = Model.Id,
                FirstName = Model.FirstName,
                SecondName = Model.SecondName,
                SurName = Model.SurName,
                Birthday = Model.Birthday,
                Age = Model.Age
            };*/

            if (Model.Id == 0)
                _EmployeesData.Add(Model.FromView());
            else
                _EmployeesData.Edit(Model.FromView());

            _EmployeesData.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(employee.ToView());
            /*
            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                SecondName = employee.SecondName,
                SurName = employee.SurName,
                Birthday = employee.Birthday,
                Age = employee.Age
            });*/
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            _EmployeesData.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}