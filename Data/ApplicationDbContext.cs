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
        public DbSet<Months> Months_table { get;set; }
        public DbSet<Terms> Terms_table { get; set; }

        public DbSet<JigRegistration> Jig_table { get; set; }

    }
}
