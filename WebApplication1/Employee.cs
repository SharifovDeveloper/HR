using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(23)]
        public string Name { get; set; }
        [Required]
        [StringLength(23), MinLength(3)]
        public string Department { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
