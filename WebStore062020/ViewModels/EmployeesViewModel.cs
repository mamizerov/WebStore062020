using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore062020.ViewModels
{
    public class EmployeesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Возраст является обязательным")]
        [Range(20, 80, ErrorMessage = "Возраст должен быть в пределах от 20 до 80 лет")]
        public int Age { get; set; }

        [Display(Name = "День рождения")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия является обязательным")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строи фамилии должна быть от 3 до 200 символов")]
        public string SurName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя является обязательным")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строи имени должна быть от 3 до 200 символов")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Ошибка формата имени. Либо русские буквы, либо латиница. Никаких цифр!")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string SecondName { get; set; }


    }
}
