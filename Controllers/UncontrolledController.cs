using Calibration_Management_System.Data;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Calibration_Management_System.Controllers
{
    public class UncontrolledController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UncontrolledController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            List<Uncontrolled> uncontrolled;
            uncontrolled = _context.Uncontrolled_table.OrderByDescending(x => x.id).ToList();
            return View(uncontrolled);
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Create()
        {
            Uncontrolled uncontrolled = new Uncontrolled();
            ViewBag.Dept = GetDept();
            return View(uncontrolled);
        }

        [HttpPost]
        public IActionResult Create(Uncontrolled uncontrolled)
        {

            _context.Uncontrolled_table.Add(uncontrolled);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Uncontrolled uncontrolled = _context.Uncontrolled_table.FirstOrDefault(r => r.id == Id);
            ViewBag.Dept = GetDept();
            return View("Edit", uncontrolled);
        }


        [HttpPost]
        public IActionResult Edit(Uncontrolled uncontrolled)
        {
            _context.Attach(uncontrolled);
            _context.Entry(uncontrolled).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Uncontrolled init = _context.Uncontrolled_table.Where(a => a.id == Id).FirstOrDefault();
            ViewBag.Dept = GetDept();
            return View(init);
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
