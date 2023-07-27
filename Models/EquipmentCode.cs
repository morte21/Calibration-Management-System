using System.ComponentModel.DataAnnotations;

namespace Calibration_Management_System.Models
{
    public class EquipmentCode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EquipmentCode_ { get; set; } = "";
    }
}
