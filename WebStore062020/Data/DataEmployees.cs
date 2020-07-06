using System;
using System.Collections.Generic;
using WebStore062020.Models;

namespace WebStore062020.Data
{
    public class DataEmployees
    {
        public static List<Employee>Employees { get; } = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Age = 23,
                Birthday = Convert.ToDateTime("20.10.1997"),
                SurName = "Гикбрейнс",
                FirstName = "Павел",
                SecondName = "Викторович"
            },
            new Employee
            {
                Id = 2,
                Age = 33,
                Birthday = Convert.ToDateTime("02.04.1987"),
                SurName = "Зайцев",
                FirstName = "Александр",
                SecondName = "Сергеевич"
            },
            new Employee
            {
                Id = 3,
                Age = 43,
                Birthday = Convert.ToDateTime("15.01.1977"),
                SurName = "Ловчев",
                FirstName = "Владимир",
                SecondName = "Алексеевич"
            },
            new Employee
            {
                Id = 4,
                Age = 53,
                Birthday = Convert.ToDateTime("15.01.1967"),
                SurName = "Петров",
                FirstName = "Виктор",
                SecondName = "Палыч"
            },

        };
    }
}
