using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calibration_Management_System.Models
{
    public class NCR
    {
        [Key]
        public int id { get; set; }

        [DisplayName("NCR #")]
        public string? fld_nonConReportNo { get; set; } = "";

        [DisplayName("Date Issued")]
        public string? fld_dateIssue { get; set; } = "";

        [DisplayName("Control Number")]
        public string? fld_ctrlNo { get; set; } = "";

        [DisplayName("Issued to")]
        public string? fld_IssueTo { get; set; } = "";

        [DisplayName("Main Incharge")]
        public string? fld_mainIncharge { get; set; } = "";

        [DisplayName("Model Number")]
        public string? fld_modelNo { get; set; } = "";

        [DisplayName("Quantity")]
        public string? fld_qty { get; set; } = "";

        [DisplayName("With disposal form")]
        public string? fld_withDisposalForm { get; set; } = "";

        [DisplayName("Contents")]
        public string? fld_contents { get; set; } = "";

        [DisplayName("Date Completed")]
        public string? fld_dateCompleted { get; set; } = "";

        [DisplayName("Status")]
        public string? fld_status { get; set; } = "";

        [DisplayName("Calib Report #")]
        public string? fld_calibReportNo { get; set; } = "";

        [DisplayName("Give form to")]
        public string? fld_giveDisposeSuspendedForm { get; set; } = "";

        [DisplayName("Given to")]
        public string? fld_givenTo { get; set; } = "";

        [DisplayName("Received form by")]
        public string? fld_rcvDisposeSuspendedForm { get; set; } = "";

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


