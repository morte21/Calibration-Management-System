using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Calibration_Management_System.Models
{
    public class EmailList
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Email")]
        public string? fld_emailAddress { get; set; } = "";

        [DisplayName("Department/Section")]
        public string? fld_dept { get; set; } = "";

        [DisplayName("Contact Person")]
        public string? fld_contactPerson { get; set; } = "";
    }
}
