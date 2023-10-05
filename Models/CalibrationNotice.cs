using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calibration_Management_System.Models
{
    public class CalibrationNotice
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Register Date")]
        public DateTime? fld_dateCreated { get; set; }

        [DisplayName("EQP")]
        public string? fld_pathEQP { get; set; } = "";
        [NotMapped]
        public IFormFile _pathEQP { get; set; }

        [DisplayName("JIG")]
        public string? fld_pathJIG { get; set; } = "";
        [NotMapped]
        public IFormFile _pathJIG { get; set; }


        [DisplayName("Status")]
        public string? fld_stat { get; set; } = "";

        [DisplayName("Approval Date")]
        public DateTime? fld_dateApproved { get; set; }

        [DisplayName("Month")]
        public string fld_calibMonth { get; set; } = "";

        [DisplayName("Year")]
        public string fld_calibYear { get; set; } = "";
    }
}
