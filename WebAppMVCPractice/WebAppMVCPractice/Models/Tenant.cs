using System.ComponentModel.DataAnnotations;

namespace WebAppMVCPractice.Models
{
    public class Tenant
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните поле с фамилией.")]
        [Display(Name = "Фамилия")]
        [RegularExpression(@"^[а-яА-ЯёЁ-]+|[a-zA-Z-]+$",
        ErrorMessage = "Фамилия введена некорректно.")]
        public string Surn { get; set; }

        [Required(ErrorMessage = "Заполните поле с именем.")]
        [Display(Name = "Имя")]
        [RegularExpression(@"^[а-яА-ЯёЁ-]+|[a-zA-Z-]+$",
        ErrorMessage = "Имя введено некорректно.")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        [RegularExpression(@"^[а-яА-ЯёЁ-]+|[a-zA-Z-]+$",
        ErrorMessage = "Отчество введено некорректно.")]
        public string Patr { get; set; }

        [Required(ErrorMessage = "Заполните поле с почтой.")]
        [Display(Name = "Почта")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Почта введена некорректно.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Заполните поле с номером телефона.")]
        [Display(Name = "Номер телефона")]
        [RegularExpression(@"^[0-9]+",
        ErrorMessage = "Номер телефона введен некорректно.")]
        public string Phone { get; set; }
    }
}
