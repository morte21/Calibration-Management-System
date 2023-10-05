using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calibration_Management_System.Models
{
    public class SuspendDisposeRegistration
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Register Date")]
        public DateTime? fld_dateReg { get; set; } = DateTime.UtcNow;

        [DisplayName("Control Number")]
        public string? fld_ctrlNo { get; set; } = "";

        [DisplayName("Item Name")]
        public string? fld_itemName { get; set; } = "";

        [DisplayName("Type")]
        public string? fld_calibType { get; set; } = "";

        [DisplayName("Model Number")]
        public string? fld_modelNo { get; set; } = "";

        [DisplayName("Serial Number")]
        public string? fld_serial { get; set; } = "";

        [DisplayName("Brand/Maker")]
        public string? fld_brand { get; set; } = "";

        [DisplayName("Department/Section")]
        public string? fld_reqFunction { get; set; } = "";

        [DisplayName("Fixed Asset")]
        public string? fld_fixedAsset { get; set; } = "";

        [DisplayName("Requested by")]
        public string? fld_requestBy { get; set; } = "";

        [DisplayName("Approved by")]
        public string? fld_approvedBy { get; set; } = "";

        [DisplayName("Reason")]
        public string? fld_reason { get; set; } = "";

        [DisplayName("Drawing Number")]
        public string? fld_drawingNo { get; set; } = "";

        [DisplayName("Suspend Date")]
        public string? fld_suspendedDate { get; set; } = "";

        [DisplayName("Disposal Date")]
        public string? fld_disposalDate { get; set; } = "";

        [DisplayName("Date submit")]
        public string? fld_submitdate { get; set; } = "";

        [DisplayName("Received by")]
        public string? fld_receivedBy { get; set; } = "";

        [DisplayName("Status")]
        public string? fld_reqStatus { get; set; } = "";

        [DisplayName("Calibration incharge")]
        public string? fld_inchargeQA { get; set; } = "";

        [DisplayName("Follow-up date")]
        public string? fld_followUpDate { get; set; } = "";

        [DisplayName("Next follow-up date")]
        public string? fld_nextFollowUp { get; set; } = "";

        [DisplayName("Requestor Name")]
        public string? fld_inchargeRequestor { get; set; } = "";


    }
}
