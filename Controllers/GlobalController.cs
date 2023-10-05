using Calibration_Management_System.Data;
using Calibration_Management_System.Migrations;
using Calibration_Management_System.Models;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Calibration_Management_System.Controllers
{   
    public class GlobalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GlobalController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewGlobal()
        {
            var calibrationNotice = _context.CalibrationNotice_table.FirstOrDefault();
            var equipmentRegistration = _context.Equipment_table.FirstOrDefault();
            var failureReport = _context.FailureReport_table.FirstOrDefault();
            var jigRegistration = _context.Jig_table.FirstOrDefault();
            var ncr = _context.NCR_table.FirstOrDefault();
            var generalForm = _context.GeneralForm_table.FirstOrDefault();
            var suspendDisposed = _context.SuspendDispose_table.FirstOrDefault();
            var registration = _context.Registration_Table.FirstOrDefault();
            var uncontrolled = _context.Uncontrolled_table.FirstOrDefault();

            var viewModel = new GlobalControllerClass
            {
                CalibrationNoticeData = calibrationNotice,
                EquipmentRegistrationData = equipmentRegistration,
                FailureReportData = failureReport,
                JigRegistrationData = jigRegistration,
                NcrData = ncr,
                GeneralFormData = generalForm,
                SuspendDisposeRegistrationData = suspendDisposed,
                RegistrationClassData = registration,
                UncontrolledData = uncontrolled

            };      
            return View(viewModel);
        }
    }
}

