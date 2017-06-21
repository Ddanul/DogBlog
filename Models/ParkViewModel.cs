using System.ComponentModel.DataAnnotations;
namespace dogblog.Models
{
    public class ParkViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
    }
}