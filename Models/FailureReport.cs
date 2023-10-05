using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calibration_Management_System.Models
{
    public class FailureReport
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Report Number")]
        public string? fld_reportNo { get; set; } = "";

        [DisplayName("Date Issued")]
        public string? fld_dateIssue { get; set; } = "";

        [DisplayName("Dept & Sec")]
        public string? fld_deptsec { get; set; } = "";

        [DisplayName("In-charge")]
        public string? fld_incharge { get; set; } = "";

        [DisplayName("Main In-charge")]
        public string? fld_mainincharge { get; set; } = "";

        [DisplayName("Control Number")]
        public string? fld_ctrlNo { get; set; } = "";

        [DisplayName("Equipment Name")]
        public string? fld_EquipName { get; set; } = "";

        [DisplayName("Quantity")]
        public string? fld_qty { get; set; } = "";

        [DisplayName("Contents")]
        public string? fld_contents { get; set; } = "";

        [DisplayName("pathDoc")]
        public string? fld_pathDoc { get; set; } = "";

        [NotMapped]
        public IFormFile _pathDoc { get; set; }

        [DisplayName("pathImg")]
        public string? fld_pathIMG { get; set; } = "";

        [NotMapped]
        public IFormFile _pathIMG { get; set; }



        
    }
}
