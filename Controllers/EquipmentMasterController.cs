using Calibration_Management_System.Data;
using Calibration_Management_System.Migrations;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Calibration_Management_System.Controllers
{
    public class EquipmentMasterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EquipmentMasterController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            List<EquipmentRegistration> equipmentRegistrations;
            //equipmentRegistrations = _context.Equipment_table.ToList();
            //equipmentRegistrations = _context.Equipment_table.OrderByDescending(x => x.id).ToList();

            //SORT THE TABLE
            equipmentRegistrations = _context.Equipment_table.Where(x => x.fld_passFail == "PASS").ToList();


            ViewBag.Category = GetCategory();
            ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();

            return View(equipmentRegistrations);
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Create()
        {
            EquipmentRegistration equipmentRegistration = new EquipmentRegistration();

            ViewBag.Category = GetCategory();
            ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();
            return View(equipmentRegistration);
        }


        [HttpPost]
        public IActionResult Create(EquipmentRegistration equipmentRegistration, IFormFile _pathIMG, IFormFile _pathDoc)
        {
            //img
            if (_pathIMG != null && _pathIMG.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"equipment"}-{equipmentRegistration.fld_ctrlNo}-{_pathIMG.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathIMG.CopyTo(fileStream);
                }

                equipmentRegistration.fld_pathIMG = uniqueFileNameIMG;
            }

            //doc
            if (_pathDoc != null && _pathDoc.Length > 0)
            {
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"equipment"}-{equipmentRegistration.fld_ctrlNo}-{_pathDoc.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathDoc.CopyTo(fileStream);
                }

                equipmentRegistration.fld_pathDoc = uniqueFileNameDoc;
            }

            _context.Equipment_table.Add(equipmentRegistration);
            _context.SaveChanges();

            return RedirectToAction("Index");
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




        [Authorize(Roles = "Control Function,Admin-Calibration")]
        public IActionResult EditGet(string fld_codeNo, string fld_eqpName, string fld_eqpModelNo, string fld_serial, string fld_brand, string fld_reqFunction, string fld_ctrlNo)
        {
            // Create a new instance of the EquipmentMaster model and assign the values from RegistrationController
            EquipmentRegistration model = new EquipmentRegistration
            {

                fld_codeNo = fld_codeNo,
                fld_eqpName = fld_eqpName,
                fld_eqpModelNo = fld_eqpModelNo,
                fld_serial = fld_serial,
                fld_brand = fld_brand,
                fld_reqFunction = fld_reqFunction,
                fld_division = fld_reqFunction,
                fld_ctrlNo = fld_ctrlNo,
            };



            ViewBag.Category = GetCategory();
            ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();



            // Pass the model to the Edit view
            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            EquipmentRegistration init = _context.Equipment_table
                .Where(a => a.id == Id)
                .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.


            ViewBag.Category = GetCategory();
            ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();

            return View(init);
        }


        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            EquipmentRegistration init = _context.Equipment_table
                .Where(a => a.id == Id)
                .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.


            ViewBag.Category = GetCategory();
            ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();

            return View(init);
        }



        [HttpPost]
        public IActionResult Edit(int id, EquipmentRegistration equipmentRegistration, IFormFile _pathIMG, IFormFile _pathDoc)
        {
            var existingEquipment = _context.Equipment_table.Find(id);

            if (existingEquipment == null)
            {
                return NotFound();
            }

            // Update the properties of the existingEquipment object with the new values from equipmentRegistration
            existingEquipment.fld_codeNo = equipmentRegistration.fld_codeNo;
            existingEquipment.fld_ctrlNo = equipmentRegistration.fld_ctrlNo;
            existingEquipment.fld_division = equipmentRegistration.fld_division;
            existingEquipment.fld_category = equipmentRegistration.fld_category;
            existingEquipment.fld_code2 = equipmentRegistration.fld_code2;
            existingEquipment.fld_eqpName = equipmentRegistration.fld_eqpName;
            existingEquipment.fld_eqpModelNo = equipmentRegistration.fld_eqpModelNo;
            existingEquipment.fld_serial = equipmentRegistration.fld_serial;
            existingEquipment.fld_brand = equipmentRegistration.fld_brand;
            existingEquipment.fld_term = equipmentRegistration.fld_term;
            existingEquipment.fld_reqFunction = equipmentRegistration.fld_reqFunction;
            existingEquipment.fld_passFail = equipmentRegistration.fld_passFail;
            existingEquipment.fld_registrationDate = equipmentRegistration.fld_registrationDate;
            existingEquipment.fld_imte = equipmentRegistration.fld_imte;
            existingEquipment.fld_calibDate = equipmentRegistration.fld_calibDate;
            existingEquipment.fld_calibMonth = equipmentRegistration.fld_calibMonth;
            existingEquipment.fld_calibYear = equipmentRegistration.fld_calibYear;
            existingEquipment.fld_nextCalibDate = equipmentRegistration.fld_nextCalibDate;
            existingEquipment.fld_nextCalibMonth = equipmentRegistration.fld_nextCalibMonth;
            existingEquipment.fld_nextCalibYear = equipmentRegistration.fld_nextCalibYear;
            existingEquipment.fld_internalExternal = equipmentRegistration.fld_internalExternal;
            existingEquipment.fld_supplierExternal = equipmentRegistration.fld_supplierExternal;
            existingEquipment.fld_comment = equipmentRegistration.fld_comment;
            existingEquipment.fld_appStandardEqp = equipmentRegistration.fld_appStandardEqp;
            existingEquipment.fld_stat = equipmentRegistration.fld_stat;
            existingEquipment.fld_calibResult = equipmentRegistration.fld_calibResult;
            existingEquipment.fld_imgResult = equipmentRegistration.fld_imgResult;
            existingEquipment.fld_updatedToSystem = equipmentRegistration.fld_updatedToSystem;
            existingEquipment.fld_updatedToMasterlist = equipmentRegistration.fld_updatedToMasterlist;
            existingEquipment.fld_withNCR = equipmentRegistration.fld_withNCR;
            existingEquipment.fld_withFailureReport = equipmentRegistration.fld_withFailureReport;
            existingEquipment.fld_withDisSus = equipmentRegistration.fld_withDisSus;


            if (_pathIMG != null && _pathIMG.Length > 0)
            {
                // Delete the previous image, if it exists
                if (!string.IsNullOrEmpty(existingEquipment.fld_pathIMG))
                {
                    string previousImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", existingEquipment.fld_pathIMG);
                    if (System.IO.File.Exists(previousImagePath))
                    {
                        System.IO.File.Delete(previousImagePath);
                    }
                }

                // Save the new image
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"equipment"}-{equipmentRegistration.fld_ctrlNo}-{_pathIMG.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathIMG.CopyTo(fileStream);
                }

                existingEquipment.fld_pathIMG = uniqueFileNameIMG;
            }

            if (_pathDoc != null && _pathDoc.Length > 0)
            {
                // Delete the previous document, if it exists
                if (!string.IsNullOrEmpty(existingEquipment.fld_pathDoc))
                {
                    string previousDocPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", existingEquipment.fld_pathDoc);
                    if (System.IO.File.Exists(previousDocPath))
                    {
                        System.IO.File.Delete(previousDocPath);
                    }
                }

                // Save the new document
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"equipment"}-{equipmentRegistration.fld_ctrlNo}-{_pathDoc.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathDoc.CopyTo(fileStream);
                }

                existingEquipment.fld_pathDoc = uniqueFileNameDoc;
            }

            _context.Attach(existingEquipment);
            _context.Entry(existingEquipment).State = EntityState.Modified;
            _context.Entry(existingEquipment).Property(f => f.fld_pathIMG).IsModified = _pathIMG != null;
            _context.Entry(existingEquipment).Property(f => f.fld_pathDoc).IsModified = _pathDoc != null;
            _context.SaveChanges();

            return RedirectToAction("Index");
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

        private List<SelectListItem> GetEqpCode()
        {
            List<SelectListItem> selAssyLine = _context.EquipmentCode_table
                .OrderBy(n => n.Id)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.EquipmentCode_.ToString(),
                    Text = n.EquipmentCode_
                }).ToList();

            var selItem = new SelectListItem()
            {
                Value = "",
                Text = "Select Code"
            };

            selAssyLine.Insert(0, selItem);
            return selAssyLine;
        }


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
