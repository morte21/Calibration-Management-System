using Calibration_Management_System.Data;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Calibration_Management_System.Controllers
{
    public class JigMasterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public JigMasterController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<JigRegistration> jigRegistrations;
            jigRegistrations = _context.Jig_table.ToList();

            ViewBag.Category = GetCategory();
            //ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();


            return View(jigRegistrations);
        }

        [Authorize(Roles = "Control Function,Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            JigRegistration jigRegistrations = new JigRegistration();

            ViewBag.Category = GetCategory();
            //ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();

            return View(jigRegistrations);
        }

        [HttpPost]
        public IActionResult Create(JigRegistration jigRegistrations, IFormFile _pathIMG, IFormFile _pathDoc)
        {
            //img
            if (_pathIMG != null && _pathIMG.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{jigRegistrations.fld_ctrlNo}-{_pathIMG.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathIMG.CopyTo(fileStream);
                }

                jigRegistrations.fld_pathIMG = uniqueFileNameIMG;
            }

            //doc
            if (_pathDoc != null && _pathDoc.Length > 0)
            {
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{jigRegistrations.fld_ctrlNo}-{_pathDoc.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathDoc.CopyTo(fileStream);
                }

                jigRegistrations.fld_pathDoc = uniqueFileNameDoc;
            }

            _context.Jig_table.Add(jigRegistrations);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Control Function,Admin")]
        public IActionResult EditGet(string fld_codeNo, string fld_jigName, string fld_drawingNo, string fld_serial, string fld_reqFunction, string fld_ctrlNo)
        {
            // Create a new instance of the EquipmentMaster model and assign the values from RegistrationController
            JigRegistration model = new JigRegistration
            {

                fld_codeNo = fld_codeNo,
                fld_jigName = fld_jigName,
                fld_drawingNo = fld_drawingNo,
                fld_serialNo = fld_serial,
                
                fld_reqFunction = fld_reqFunction,
                fld_division = fld_reqFunction,
                fld_ctrlNo = fld_ctrlNo,
            };



            ViewBag.Category = GetCategory();
            //ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();



            // Pass the model to the Edit view
            return View(model);
        }

        [Authorize(Roles = "Control Function,Admin")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            JigRegistration init = _context.Jig_table
                .Where(a => a.id == Id)
                .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.


            ViewBag.Category = GetCategory();
            //ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();

            return View(init);
        }



        [HttpPost]
        public IActionResult Edit(int id, JigRegistration jigRegistrations, IFormFile _pathIMG, IFormFile _pathDoc)
        {
            var existingJig = _context.Jig_table.Find(id);

            if (existingJig == null)
            {
                return NotFound();
            }

            // Update the properties of the existingJig object with the new values from jigRegistrations
            existingJig.fld_codeNo = jigRegistrations.fld_codeNo;
            existingJig.fld_ctrlNo = jigRegistrations.fld_ctrlNo;
            existingJig.fld_division = jigRegistrations.fld_division;
            existingJig.fld_jigName = jigRegistrations.fld_jigName;
            existingJig.fld_drawingNo = jigRegistrations.fld_drawingNo;
            existingJig.fld_serialNo = jigRegistrations.fld_serialNo;
            existingJig.fld_term = jigRegistrations.fld_term;
            existingJig.fld_reqFunction = jigRegistrations.fld_reqFunction;
            existingJig.fld_passfail = jigRegistrations.fld_passfail;
            existingJig.fld_registrationDate = jigRegistrations.fld_registrationDate;
            existingJig.fld_imte = jigRegistrations.fld_imte;
            existingJig.fld_calibDate = jigRegistrations.fld_calibDate;
            existingJig.fld_calibMonth = jigRegistrations.fld_calibMonth;
            existingJig.fld_calibYear = jigRegistrations.fld_calibYear;
            existingJig.fld_nextCalibDate = jigRegistrations.fld_nextCalibDate;
            existingJig.fld_nextCalibMonth = jigRegistrations.fld_nextCalibMonth;
            existingJig.fld_nextCalibYear = jigRegistrations.fld_nextCalibYear;
            existingJig.fld_internalExternal = jigRegistrations.fld_internalExternal;
            existingJig.fld_remarks = jigRegistrations.fld_remarks;
            existingJig.fld_stat = jigRegistrations.fld_stat;
            existingJig.fld_description = jigRegistrations.fld_description;



            if (_pathIMG != null && _pathIMG.Length > 0)
            {
                // Delete the previous image, if it exists
                if (!string.IsNullOrEmpty(existingJig.fld_pathIMG))
                {
                    string previousImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", existingJig.fld_pathIMG);
                    if (System.IO.File.Exists(previousImagePath))
                    {
                        System.IO.File.Delete(previousImagePath);
                    }
                }

                // Save the new image
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{jigRegistrations.fld_ctrlNo}-{_pathIMG.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathIMG.CopyTo(fileStream);
                }

                existingJig.fld_pathIMG = uniqueFileNameIMG;
            }

            if (_pathDoc != null && _pathDoc.Length > 0)
            {
                // Delete the previous document, if it exists
                if (!string.IsNullOrEmpty(existingJig.fld_pathDoc))
                {
                    string previousDocPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", existingJig.fld_pathDoc);
                    if (System.IO.File.Exists(previousDocPath))
                    {
                        System.IO.File.Delete(previousDocPath);
                    }
                }

                // Save the new document
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{jigRegistrations.fld_ctrlNo}-{_pathDoc.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathDoc.CopyTo(fileStream);
                }

                existingJig.fld_pathDoc = uniqueFileNameDoc;
            }

            //_context.Attach(jigRegistrations);
            //_context.Entry(jigRegistrations).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int Id)
        {
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            JigRegistration init = _context.Jig_table
                .Where(a => a.id == Id)
                .FirstOrDefault();
            #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            ViewBag.Category = GetCategory();
            //ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();

            return View(init);
        }



        public int GetRecentValue(string category, string code2)
        {
            string searchTerm = category + code2;

            // Retrieve the recent values from the database based on fld_ctrlNo
            var recentValues = _context.Equipment_table
                .Where(e => e.fld_ctrlNo.StartsWith(searchTerm))
                .Select(e => e.fld_ctrlNo.Substring(searchTerm.Length))
                .ToList();

            int recentValue;
            if (recentValues.Count > 0)
            {
                // Parse the values and get the maximum
                recentValue = recentValues.Select(s => int.TryParse(s, out int value) ? value : 0).Max();
            }
            else
            {
                // If no values found, set the recent value to 0
                recentValue = 0;
            }

            return recentValue;
        }


        //get the value of department to code via db and js
        [HttpGet]
        public IActionResult GetCodeByDepartment(string department)
        {
            // Retrieve the code based on the department from the database or any other data source
            var fld_codeNo = _context.RequestingFunction_table
                .FirstOrDefault(n => n.Department == department)?.Code;

            // Return the code as JSON
            return Json(fld_codeNo);
        }

        private List<SelectListItem> GetCategory()
        {
            List<SelectListItem> selAssyLine = _context.Category_table
                .OrderBy(n => n.Id)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Category_.ToString(),
                    Text = n.Category_
                }).ToList();

            var selItem = new SelectListItem()
            {
                Value = "",
                Text = "Select Category"
            };

            selAssyLine.Insert(0, selItem);
            return selAssyLine;
        }

        //private List<SelectListItem> GetEqpCode()
        //{
        //    List<SelectListItem> selAssyLine = _context.Jig_table
        //        .OrderBy(n => n.id)
        //        .Select(n =>
        //        new SelectListItem
        //        {
        //            Value = n.EquipmentCode_.ToString(),
        //            Text = n.EquipmentCode_
        //        }).ToList();

        //    var selItem = new SelectListItem()
        //    {
        //        Value = "",
        //        Text = "Select Code"
        //    };

        //    selAssyLine.Insert(0, selItem);
        //    return selAssyLine;
        //}


        private List<SelectListItem> GetMonths()
        {
            List<SelectListItem> selAssyLine = _context.Months_table
                .OrderBy(n => n.Id)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Months_.ToString(),
                    Text = n.Months_
                }).ToList();

            var selItem = new SelectListItem()
            {
                Value = "",
                Text = "Select Month"
            };

            selAssyLine.Insert(0, selItem);
            return selAssyLine;
        }

        private List<SelectListItem> GetTerms()
        {
            List<SelectListItem> selAssyLine = _context.Terms_table
                .OrderBy(n => n.Id)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Terms_.ToString(),
                    Text = n.Terms_
                }).ToList();

            var selItem = new SelectListItem()
            {
                Value = "",
                Text = "Select Terms"
            };

            selAssyLine.Insert(0, selItem);
            return selAssyLine;
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
                Value = "PASS",
                Text = "PASS"
            };
            selStatus.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "FAIL",
                Text = "FAIL"
            };
            selStatus.Add(selItem);

            return selStatus;
        }

        private List<SelectListItem> GetDivision()
        {
            List<SelectListItem> selStatus = new List<SelectListItem>();
            var selItem = new SelectListItem() { Value = "", Text = "Select" };
            selStatus.Insert(0, selItem);
            selItem = new SelectListItem()
            {
                Value = "Cooling",
                Text = "Cooling"
            };
            selStatus.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "UPS",
                Text = "UPS"
            };
            selStatus.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "Servo",
                Text = "Servo"
            };
            selStatus.Add(selItem);

            return selStatus;
        }


        private List<SelectListItem> GetIntExt()
        {
            List<SelectListItem> selStatus = new List<SelectListItem>();
            var selItem = new SelectListItem() { Value = "", Text = "Select" };
            selStatus.Insert(0, selItem);
            selItem = new SelectListItem()
            {
                Value = "Internal",
                Text = "Internal"
            };
            selStatus.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "External",
                Text = "External"
            };
            selStatus.Add(selItem);

            return selStatus;
        }


    }
}
