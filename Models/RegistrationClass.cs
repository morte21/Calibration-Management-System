using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calibration_Management_System.Models
{
    public class RegistrationClass
    {
        [Key]
        public int id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        [DisplayName("Register Date")]
        public DateTime? fld_dateReg { get; set; } = DateTime.UtcNow;

        [DisplayName("Request Function")]
        public string? fld_reqFunction { get; set; } = "";

        [DisplayName("In-charge")]
        public string? fld_incharge { get; set; } = "";

        [DisplayName("Approved by")]
        public string? fld_approvedBy { get; set; } = "";

        [DisplayName("Code Number")]
        public string? fld_codeNo { get; set; } = "";

        [DisplayName("Re-reg Eqp. Control Number")]
        public string? fld_ctrlNo { get; set; } = "";

        [DisplayName("Equipment Name")]
        public string? fld_eqpName { get; set; } = "";

        [DisplayName("Equipment Model Number")]
        public string? fld_eqpModelNo { get; set; } = "";

        [DisplayName("Serial Number")]
        public string? fld_serial { get; set; } = "";

        [DisplayName("Brand")]
        public string? fld_brand { get; set; } = "";

        [DisplayName("Submission Date")]
        public string? fld_submissionDate { get; set; } = "";

        [DisplayName("Received by")]
        public string? fld_receivedBy { get; set; } = "";

        [DisplayName("Status")]
        public string? fld_status { get; set; } = "";

        [DisplayName("Email #1")]
        public string? fld_emailOne { get; set; } = "";

        [DisplayName("Email #2")]
        public string? fld_emailTwo { get; set; } = "";

        [DisplayName("Email #3")]
        public string? fld_emailThree { get; set; } = "";

        [DisplayName("Jig Name")]
        public string? fld_jigName { get; set; } = "";

        [DisplayName("Drawing Number")]
        public string? fld_drawingNo { get; set; } = "";

        [DisplayName("Re-reg Jig Control Number")]
        public string? fld_reRegJigCtrlNo { get; set; } = "";

        [DisplayName("Jig Category")]
        public string? fld_jigCategory { get; set; } = "";

        [DisplayName("Remarks")]
        public string? fld_remarks { get; set; } = "";
    }
}
