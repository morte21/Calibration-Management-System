using Calibration_Management_System.Data;
using Calibration_Management_System.Migrations;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Calibration_Management_System.Controllers
{
    [Authorize(Roles = "Control Function,Admin-Calibration")]
    public class EmailRegController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmailRegController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        public IActionResult Index()
        {
            List<EmailList> emailReg;
            emailReg = _context.EmailList_table.OrderByDescending(x => x.Id).ToList();
            return View(emailReg);
        }


        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Create()
        {
            EmailList emailReg = new EmailList();
            ViewBag.Dept = GetDept();
            return View(emailReg);
        }

        [HttpPost]
        public IActionResult Create(EmailList emailReg)
        {

            _context.EmailList_table.Add(emailReg);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            EmailList emailReg = _context.EmailList_table
                .Where(a => a.Id == id).FirstOrDefault();

            return View(emailReg);
        }

        [HttpPost]
        public IActionResult Delete(EmailList emailReg)
        {
            _context.Attach(emailReg);
            _context.Entry(emailReg).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        private List<SelectListItem> GetDept()
        {
            List<SelectListItem> selDept = _context.RequestingFunction_table
                .OrderBy(n => n.Id)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Department.ToString(),
                    Text = n.Department
                }).ToList();

            var selItem = new SelectListItem()
            {
                Value = "",
                Text = "Select Department"
            };

            selDept.Insert(0, selItem);
            return selDept;
        }




    }
}
