using Calibration_Management_System.Data;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Calibration_Management_System.Controllers
{
    public class NCRController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NCRController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<NCR> ncr;
            ncr = _context.NCR_table.OrderByDescending(x => x.id).ToList();
            return View(ncr);
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Create()
        {
            NCR ncr = new NCR();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.NCR = GetNCR();
            return View(ncr);
        }

        [HttpPost]
        public IActionResult Create(NCR ncr, IFormFile _pathIMG, IFormFile _pathDoc)
        {
            //img
            if (_pathIMG != null && _pathIMG.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"failure_report"}-{ncr.fld_ctrlNo}-{_pathIMG.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathIMG.CopyTo(fileStream);
                }

                ncr.fld_pathIMG = uniqueFileNameIMG;
            }

            //doc
            if (_pathDoc != null && _pathDoc.Length > 0)
            {
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"failure_report"}-{ncr.fld_ctrlNo}-{_pathDoc.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathDoc.CopyTo(fileStream);
                }

                ncr.fld_pathDoc = uniqueFileNameDoc;
            }

            _context.NCR_table.Add(ncr);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            NCR ncr = _context.NCR_table.FirstOrDefault(r => r.id == Id);
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.NCR = GetNCR();
            return View("Edit", ncr);
        }


        [HttpPost]
        public IActionResult Edit(NCR ncr, IFormFile _pathIMG, IFormFile _pathDoc)
        {

            if (_pathIMG != null && _pathIMG.Length > 0)
            {
                // Delete the previous image, if it exists
                if (!string.IsNullOrEmpty(ncr.fld_pathIMG))
                {
                    string previousImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", ncr.fld_pathIMG);
                    if (System.IO.File.Exists(previousImagePath))
                    {
                        System.IO.File.Delete(previousImagePath);
                    }
                }

                // Save the new image
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"failure_report"}-{ncr.fld_ctrlNo}-{_pathIMG.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathIMG.CopyTo(fileStream);
                }

                
                ncr.fld_pathIMG = uniqueFileNameIMG;
                

            }




            if (_pathDoc != null && _pathDoc.Length > 0)
            {
                // Delete the previous document, if it exists
                if (!string.IsNullOrEmpty(ncr.fld_pathDoc))
                {
                    string previousDocPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", ncr.fld_pathDoc);
                    if (System.IO.File.Exists(previousDocPath))
                    {
                        System.IO.File.Delete(previousDocPath);
                    }
                }

                // Save the new document
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"failure_report"}-{ncr.fld_ctrlNo}-{_pathDoc.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathDoc.CopyTo(fileStream);
                }
                    ncr.fld_pathDoc = uniqueFileNameDoc;
            }


            _context.Attach(ncr);
            _context.Entry(ncr).State = EntityState.Modified;
            _context.Entry(ncr).Property(f => f.fld_pathIMG).IsModified = _pathIMG != null;
            _context.Entry(ncr).Property(f => f.fld_pathDoc).IsModified = _pathDoc != null;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            NCR init = _context.NCR_table
                .Where(a => a.id == Id)
                .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.NCR = GetNCR();
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

        private List<SelectListItem> GetStatus()
        {
            List<SelectListItem> selStatus = new List<SelectListItem>();
            var selItem = new SelectListItem() { Value = "", Text = "Select" };
            selStatus.Insert(0, selItem);
            selItem = new SelectListItem()
            {
                Value = "Open",
                Text = "Open"
            };
            selStatus.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "Closed",
                Text = "Closed"
            };
            selStatus.Add(selItem);

            return selStatus;
        }

        private List<SelectListItem> GetNCR()
        {
            List<SelectListItem> selStatus = new List<SelectListItem>();
            var selItem = new SelectListItem() { Value = "", Text = "Select" };
            selStatus.Insert(0, selItem);
            selItem = new SelectListItem()
            {
                Value = "O",
                Text = "O"
            };
            selStatus.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "X",
                Text = "X"
            };
            selStatus.Add(selItem);

            return selStatus;
        }
    }
}
