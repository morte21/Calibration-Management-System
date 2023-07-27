using System.ComponentModel.DataAnnotations;

namespace Calibration_Management_System.Models
{
    public class RequestingFunction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Department { get; set; } = "";

        [Required]
        public string Code { get; set; } = "";
    }
}
