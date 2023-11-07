using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calibration_Management_System.Models
{
    public class CalibrationResultJIG
    {
        

        [DisplayName("Calibration Date")]
        public string? calibrationdate { get; set; } = "";

        [DisplayName("Actual Due Date")]
        public string? fld_actualCalibDueDate { get; set; } = "";

        [DisplayName("Control Number.")]
        public string? fld_ctrlNo { get; set; } = "";

        
        [DisplayName("Jig Name")]
        public string? fld_jigName { get; set; } = "";

        [DisplayName("Drawing Number")]
        public string? fld_drawingNo { get; set; } = "";

        [DisplayName("Term")]
        public string? fld_term { get; set; } = "";

        [DisplayName("Department/Section")]
        public string? fld_reqFunction { get; set; } = "";

        [DisplayName("Remarks")]
        public string? fld_remarks { get; set; } = "";


        [DisplayName("Pas/Fail")]
        public string? fld_passfail { get; set; } = "";

        [DisplayName("Expiration Period")]
        public string? fld_imte { get; set; } = "";

        [DisplayName("Date Received")]
        public string? fld_dateRecv { get; set; } = "";

        [DisplayName("Calibration Date")]
        public string? fld_calibDate { get; set; } = "";

        [DisplayName("Calibration Month")]
        public string? fld_calibMonth { get; set; } = "";

        [DisplayName("Calibration Year")]
        public string? fld_calibYear { get; set; } = "";

        [DisplayName("Next Calib. Date")]
        public string? fld_nextCalibDate { get; set; } = "";

        [DisplayName("Next Calib. Month")]
        public string? fld_nextCalibMonth { get; set; } = "";

        [DisplayName("Next Calib. Year")]
        public string? fld_nextCalibYear { get; set; } = "";

        [DisplayName("Return Date")]
        public string? fld_dateReturned { get; set; } = "";

        [DisplayName("Internal/External")]
        public string? fld_internalExternal { get; set; } = "";

        [DisplayName("W/ NC")]
        public string? fld_withNC { get; set; } = "";

        [DisplayName("W/ Failure Report")]
        public string? fld_CalibFR { get; set; } = "";

        [DisplayName("W/ Suspension/Dispose")]
        public string? fld_calibDisSusForm { get; set; } = "";

        [DisplayName("W/ Result")]
        public string? fld_withCalibResult { get; set; } = "";

        [DisplayName("DOC")]
        public string? fld_pathDoc { get; set; } = "";

        [DisplayName("DOC")]
        [NotMapped]
        public IFormFile _pathDoc { get; set; }
        
        public string? fld_pathIMG { get; set; } = "";
        [DisplayName("IMG")]
        [NotMapped]
        public IFormFile _pathIMG { get; set; }

        [DisplayName("Status")]
        public string? fld_stat { get; set; } = "";

        [DisplayName("Incharge")]
        public string? fld_incharge { get; set; } = "";
        
        [DisplayName("Change Sticker")]
        public string? fld_changeSticker { get; set; } = "";

        [DisplayName("Code No.")]
        public string? fld_codeNo { get; set; } = "";

        [DisplayName("Month")]
        public string? fld_month { get; set; } = "";

        [DisplayName("Year")]
        public string? fld_year { get; set; } = "";

        [Key]
        public int id { get; set; }

    }
}
