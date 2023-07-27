using System.ComponentModel.DataAnnotations;

namespace Calibration_Management_System.Models
{
    public class Terms
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Terms_ { get; set; } = "";
    }
}
