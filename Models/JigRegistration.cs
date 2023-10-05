using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calibration_Management_System.Models
{
    public class JigRegistration
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Code")]
        public string? fld_codeNo { get; set; } = "";

        [DisplayName("Control Number")]
        public string? fld_ctrlNo { get; set; } = "";

        [DisplayName("Division")]
        public string? fld_division { get; set; } = "";

        [DisplayName("Jig")]
        public string? fld_jigName { get; set; } = "";

        [DisplayName("Drawing No.")]
        public string? fld_drawingNo { get; set; } = "";

        [DisplayName("Serial")]
        public string? fld_serialNo { get; set; } = "";

        [DisplayName("Terms")]
        public string? fld_term { get; set; } = "";

        [DisplayName("Employment Place")]
        public string? fld_reqFunction { get; set; } = "";

        [DisplayName("Pass/Fail")]
        public string? fld_passfail { get; set; } = "";

        [DisplayName("Register Date")]
        public DateTime? fld_registrationDate { get; set; } 

        [DisplayName("IMTE")]
        public string? fld_imte { get; set; } = "";

        [DisplayName("Calibration Date")]
        public DateTime? fld_calibDate { get; set; }

        [DisplayName("Calibration Month")]
        public string? fld_calibMonth { get; set; } = "";

        [DisplayName("Calibration Year")]
        public string? fld_calibYear { get; set; } = "";

        [DisplayName("Next Calibration")]
        public DateTime? fld_nextCalibDate { get; set; } 

        [DisplayName("Next Calib. Month")]
        public string? fld_nextCalibMonth { get; set; } = "";

        [DisplayName("Next Calib. Year")]
        public string? fld_nextCalibYear { get; set; } = "";

        [DisplayName("Internal/External")]
        public string? fld_internalExternal { get; set; } = "";

        [DisplayName("Remarks")]
        public string? fld_remarks { get; set; } = "";

        [DisplayName("Path DOC")]
        public string? fld_pathDoc { get; set; } = "";
        [NotMapped]
        public IFormFile _pathDoc { get; set; }


        [DisplayName("Path IMG")]
        public string? fld_pathIMG { get; set; } = "";
        [NotMapped]
        public IFormFile _pathIMG { get; set; }

        [DisplayName("Status")]
        public string? fld_stat { get; set; } = "";

        [DisplayName("Description")]
        public string? fld_description { get; set; } = "";
    }
}
