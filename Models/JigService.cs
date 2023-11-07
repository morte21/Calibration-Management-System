using Calibration_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq;

namespace Calibration_Management_System.Models
{
    public class JigService
    {
        private readonly ApplicationDbContext _context;


        public JigService(ApplicationDbContext context)
        {
            _context = context;

        }


        // JigService.cs
        public async Task<List<JigRegistration>> GetJigDataBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            // Filter the jig data based on both date ranges (fld_calibDate and selectedDates)
            return await _context.Jig_table
                .Where(j => j.fld_nextCalibDate >= startDate && j.fld_nextCalibDate <= endDate && j.fld_passfail == "PASS")
                .ToListAsync();
        }

        public async Task<List<JigRegistration>> GetJigByMonthAndYear(string selectedMonth, string selectedYear)
        {
            return await _context.Jig_table
                .Where(e => e.fld_calibYear == selectedYear && e.fld_calibMonth == selectedMonth)
                .ToListAsync();
        }
    }
}
