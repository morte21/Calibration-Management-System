using Calibration_Management_System.Controllers;
using Calibration_Management_System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calibration_Management_System.Models
{
    public class EquipmentRegistration
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Code")]
        public string? fld_codeNo { get; set; } = "";

        [DisplayName("Control Number")]
        public string? fld_ctrlNo { get; set; } = "";

        [DisplayName("Division")]
        public string? fld_division { get; set; } = "";

        [DisplayName("Category")]
        public string? fld_category { get; set; } = "";

        [DisplayName("Code")]
        public string? fld_code2 { get; set; } = "";

        [DisplayName("Equipment Name")]
        public string? fld_eqpName { get; set; } = "";

        [DisplayName("Model")]
        public string? fld_eqpModelNo { get; set; } = "";

        [DisplayName("Serial")]
        public string? fld_serial { get; set; } = "";

        [DisplayName("Maker")]
        public string? fld_brand { get; set; } = "";

        [DisplayName("Term")]
        public string? fld_term { get; set; } = "";

        [DisplayName("Employment Place")]
        public string? fld_reqFunction { get; set; } = "";

        [DisplayName("Pass/Fail")]
        public string? fld_passFail { get; set; } = "";

        [DisplayName("Registration Date")]
        public DateTime? fld_registrationDate { get; set; }

        [DisplayName("IMTE")]
        public string? fld_imte { get; set; } = "";

        [DisplayName("Calibration Date")]
        public DateTime? fld_calibDate { get; set; }

        [DisplayName("Calibration Month")]
        public string? fld_calibMonth { get; set; } = "";

        [DisplayName("Calibration Year")]
        public string? fld_calibYear { get; set; } = "";

        [DisplayName("Next Calibration Date")]
        public DateTime? fld_nextCalibDate { get; set; } 

        [DisplayName("Next Calibration Month")]
        public string? fld_nextCalibMonth { get; set; } = "";

        [DisplayName("Next Calibration Year")]
        public string? fld_nextCalibYear { get; set; } = "";

        [DisplayName("Internal/External")]
        public string? fld_internalExternal { get; set; } = "";

        [DisplayName("External Supplier")]
        public string? fld_supplierExternal { get; set; } = "";

        [DisplayName("Comment")]
        public string? fld_comment { get; set; } = "";

        [DisplayName("Standard Equipment")]
        public string? fld_appStandardEqp { get; set; } = "";

        [DisplayName("Path IMG")]
        public string? fld_pathIMG { get; set; } = "";
        [NotMapped]
        public IFormFile _pathIMG { get; set; }


        [DisplayName("Path DOC")]
        public string? fld_pathDoc { get; set; } = "";
        [NotMapped]
        public IFormFile _pathDoc { get; set; }


        [DisplayName("Status")]
        public string? fld_stat { get; set; } = "";

        [DisplayName("Calibration Result")]
        public string? fld_calibResult { get; set; } = "";

        [DisplayName("IMG Result")]
        public string? fld_imgResult { get; set; } = "";

        [DisplayName("Update to system")]
        public string? fld_updatedToSystem { get; set; } = "";

        [DisplayName("Update to masterlist")]
        public string? fld_updatedToMasterlist { get; set; } = "";

        [DisplayName("With NCR")]
        public string? fld_withNCR { get; set; } = "";

        [DisplayName("With Failure Report")]
        public string? fld_withFailureReport { get; set; } = "";

        [DisplayName("With Dis/Sus")]
        public string? fld_withDisSus { get; set; } = "";

       





    }
}
