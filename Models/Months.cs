using System.ComponentModel.DataAnnotations;

namespace Calibration_Management_System.Models
{
    public class Months
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Months_ { get; set; } = "";
    }
}
