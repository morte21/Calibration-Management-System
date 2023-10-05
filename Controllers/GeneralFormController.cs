using Calibration_Management_System.Data;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Calibration_Management_System.Controllers
{
    public class GeneralFormController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GeneralFormController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<GeneralForm> generalForm;
            generalForm = _context.GeneralForm_table.OrderByDescending(x => x.id).ToList();
            return View(generalForm);
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Create()
        {
            GeneralForm generalForm = new GeneralForm();
            return View(generalForm);
        }

        [HttpPost]
        public IActionResult Create(GeneralForm generalForm)
        {

            _context.GeneralForm_table.Add(generalForm);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            GeneralForm generalForm = _context.GeneralForm_table.FirstOrDefault(r => r.id == Id);

            return View("Edit", generalForm);
        }


        [HttpPost]
        public IActionResult Edit(GeneralForm generalForm)
        {
            _context.Attach(generalForm);
            _context.Entry(generalForm).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            GeneralForm init = _context.GeneralForm_table.Where(a => a.id == Id).FirstOrDefault();

            return View(init);
        }
    }
}
