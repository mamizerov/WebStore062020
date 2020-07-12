using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities
{
    [Table("TEmployees")]
    public class Employee
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
