using System.ComponentModel.DataAnnotations;
namespace dogblog.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string ConfPassword { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
    }
}