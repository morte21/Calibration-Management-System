using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calibration_Management_System.Models
{
    public class Uncontrolled
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Equipment Name")]
        public string? fld_nameEquip { get; set; } = "";

        [DisplayName("Model Type")]
        public string? fld_modelType { get; set; } = "";

        [DisplayName("Serial")]
        public string? fld_serial { get; set; } = "";

        [DisplayName("Maker")]
        public string? fld_maker { get; set; } = "";

        [DisplayName("Reason")]
        public string? fld_reasonUncontrolled { get; set; } = "";

        [DisplayName("Quantity")]
        public string? fld_qty { get; set; } = "";

        [DisplayName("Date Request")]
        public string? fld_reqDate { get; set; } = "";

        [DisplayName("Request by")]
        public string? fld_reqBy { get; set; } = "";

        [DisplayName("Dept/Section")]
        public string? fld_department { get; set; } = "";

        [DisplayName("Remarks/Comment")]
        public string? fld_commento { get; set; } = "";
    }
}
