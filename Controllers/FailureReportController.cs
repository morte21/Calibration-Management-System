using Calibration_Management_System.Data;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Calibration_Management_System.Controllers
{
    
    public class FailureReportController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FailureReportController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<FailureReport> failureReports;
            
            failureReports = _context.FailureReport_table.OrderByDescending(x => x.id).ToList();

            return View(failureReports);
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Create()
        {
            FailureReport failureReports = new FailureReport();
            ViewBag.Dept = GetDept();
            return View(failureReports);
        }

        [HttpPost]
        public IActionResult Create(FailureReport failureReports, IFormFile _pathIMG, IFormFile _pathDoc)
        {
            //img
            if (_pathIMG != null && _pathIMG.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"failure_report"}-{failureReports.fld_ctrlNo}-{_pathIMG.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathIMG.CopyTo(fileStream);
                }

                failureReports.fld_pathIMG = uniqueFileNameIMG;
            }

            //doc
            if (_pathDoc != null && _pathDoc.Length > 0)
            {
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"failure_report"}-{failureReports.fld_ctrlNo}-{_pathDoc.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathDoc.CopyTo(fileStream);
                }

                failureReports.fld_pathDoc = uniqueFileNameDoc;
            }

            _context.FailureReport_table.Add(failureReports);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            FailureReport failureReports = _context.FailureReport_table.FirstOrDefault(r => r.id == Id);
            ViewBag.Dept = GetDept();
            return View("Edit", failureReports);
        }


        [HttpPost]
        public IActionResult Edit(FailureReport failureReports, IFormFile _pathIMG, IFormFile _pathDoc)
        {
            
                if (_pathIMG != null && _pathIMG.Length > 0)
                {
                    // Delete the previous image, if it exists
                    if (!string.IsNullOrEmpty(failureReports.fld_pathIMG))
                    {
                        string previousImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", failureReports.fld_pathIMG);
                        if (System.IO.File.Exists(previousImagePath))
                        {
                            System.IO.File.Delete(previousImagePath);
                        }
                    }

                    // Save the new image
                    string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"failure_report"}-{failureReports.fld_ctrlNo}-{_pathIMG.FileName}";
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileNameIMG);

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        _pathIMG.CopyTo(fileStream);
                    }

                    
                    failureReports.fld_pathIMG = uniqueFileNameIMG;
                    
                    
                }
            
           

           
                if (_pathDoc != null && _pathDoc.Length > 0)
                {
                    // Delete the previous document, if it exists
                    if (!string.IsNullOrEmpty(failureReports.fld_pathDoc))
                    {
                        string previousDocPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", failureReports.fld_pathDoc);
                        if (System.IO.File.Exists(previousDocPath))
                        {
                            System.IO.File.Delete(previousDocPath);
                        }
                    }

                    // Save the new document
                    string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"failure_report"}-{failureReports.fld_ctrlNo}-{_pathDoc.FileName}";
                    string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", uniqueFileNameDoc);

                    using (var fileStream = new FileStream(docPath, FileMode.Create))
                    {
                        _pathDoc.CopyTo(fileStream);
                    }

               
                    failureReports.fld_pathDoc = uniqueFileNameDoc; 
                
                
                }
            
            
            _context.Attach(failureReports);
            _context.Entry(failureReports).State = EntityState.Modified;
            _context.Entry(failureReports).Property(f => f.fld_pathIMG).IsModified = _pathIMG != null;
            _context.Entry(failureReports).Property(f => f.fld_pathDoc).IsModified = _pathDoc != null;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            FailureReport init = _context.FailureReport_table
                .Where(a => a.id == Id)
                .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
