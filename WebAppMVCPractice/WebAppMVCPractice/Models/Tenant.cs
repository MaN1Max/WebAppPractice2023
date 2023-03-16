using System.ComponentModel.DataAnnotations;

namespace WebAppMVCPractice.Models
{
    public class Tenant
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string Surn { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Patr { get; set; }
        [Required]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }
    }
}
