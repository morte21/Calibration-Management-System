using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calibration_Management_System.Models
{
    public class GeneralForm
    {
        [Key]
        public int id { get; set; }

        [DisplayName("#")]
        public string? fld_no { get; set; } = "";

        [DisplayName("Date Estimate")]
        public string? fld_dateEst { get; set; } = "";

        [DisplayName("Equipment")]
        public string? fld_appEquipment { get; set; } = "";

        [DisplayName("Document Number")]
        public string? fld_docNo { get; set; } = "";

        [DisplayName("Revision")]
        public string? fld_rev { get; set; } = "";
    }
}
