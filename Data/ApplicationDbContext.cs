using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Calibration_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<RegistrationClass> Registration_Table { get; set; }
        public DbSet<EquipmentRegistration> Equipment_table { get; set; }
        public DbSet<RequestingFunction> RequestingFunction_table { get; set; }
        public DbSet<Category> Category_table { get; set; }
        public DbSet<EquipmentCode> EquipmentCode_table { get; set; }
        public DbSet<Months> Months_table { get; set; }
        public DbSet<Terms> Terms_table { get; set; }

        public DbSet<JigRegistration> Jig_table { get; set; }

        public DbSet<SuspendDisposeRegistration> SuspendDispose_table { get; set; }

        public DbSet<FailureReport> FailureReport_table { get; set; }

        public DbSet<Uncontrolled> Uncontrolled_table { get; set; }

        public DbSet<NCR> NCR_table { get; set; }
        public DbSet<GeneralForm> GeneralForm_table { get; set; }

        public DbSet<CalibrationNotice> CalibrationNotice_table { get; set; }

        public DbSet<EmailList> EmailList_table { get; set; }

        public DbSet<CalibrationResultEQP> CalibrationResultEQP { get; set; }

        public DbSet<CalibrationResultJIG> CalibrationResultJIG { get; set; }



    }
}
