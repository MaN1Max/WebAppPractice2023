using System.ComponentModel.DataAnnotations;

namespace WebAppMVCPractice.Models
{
    public class Tenant
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Surn { get; set; }
        [Required]
        public string Name { get; set; }
        public string Patr { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
