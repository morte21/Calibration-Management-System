using Calibration_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Calibration_Management_System.Models
{
    public class EquipmentService
    {

        private readonly ApplicationDbContext _context;
     

        public EquipmentService(ApplicationDbContext context)
        {
            _context = context;
           
        }


        // EquipmentService.cs
        public async Task<List<EquipmentRegistration>> GetEquipmentDataBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            //selectedDates = selectedDates.ToArray();
            return await _context.Equipment_table
                .Where(e => e.fld_calibDate >= startDate && e.fld_calibDate <= endDate)
                .ToListAsync();
        }

        public async Task<List<EquipmentRegistration>> GetEquipmentByMonthAndYear(string selectedMonth, string selectedYear)
        {
            return await _context.Equipment_table
                .Where(e => e.fld_calibYear == selectedYear && e.fld_calibMonth == selectedMonth)
                .ToListAsync();
        }
    }
}
