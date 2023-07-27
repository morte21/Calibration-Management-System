using System.ComponentModel.DataAnnotations;
namespace Calibration_Management_System.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category_ { get; set; } = "";

    }
}
