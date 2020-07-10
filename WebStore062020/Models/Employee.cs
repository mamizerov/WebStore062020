using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore062020.Models
{
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
