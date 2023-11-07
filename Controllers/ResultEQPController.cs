using Calibration_Management_System.Data;
using Calibration_Management_System.Migrations;
using Calibration_Management_System.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Calibration_Management_System.Controllers
{
    [Authorize(Roles = "Control Function,Admin-Calibration")]
    public class ResultEQPController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        int equipmentId;

        public ResultEQPController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<CalibrationResultEQP> calibrationResults;
            calibrationResults = _context.CalibrationResultEQP.OrderByDescending(x => x.calibrationdate).ToList();
            return View(calibrationResults);
        }

        [HttpPost]
        public IActionResult SearchSchedule(int searchMonth, int searchYear)
        {
            List<CalibrationResultEQP> searchResults;

            // Modify this query to filter by searchMonth and searchYear
            searchResults = _context.CalibrationResultEQP
                .Where(x => x.fld_month == searchMonth.ToString() && x.fld_year == searchYear.ToString())
                .OrderByDescending(x => x.calibrationdate)
                .ToList();

            return Json(searchResults);


        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {

            //get global value from other controller
            GlobalControllerClass globalResultEQP = new GlobalControllerClass();

            globalResultEQP.CalibrationResultEQP = _context.CalibrationResultEQP.FirstOrDefault(r => r.id == Id);

            // Find the Equipment_table record with matching fld_ctrl
            EquipmentRegistration equipmentRecord = _context.Equipment_table.FirstOrDefault(e => e.fld_ctrlNo == globalResultEQP.CalibrationResultEQP.fld_ctrlNo);

            if (equipmentRecord != null)
            {
                // You can access the id of the Equipment_table record here
                equipmentId = equipmentRecord.id;
                ViewBag.EquipmentId = equipmentId; // Store the equipment id in ViewBag or ViewData for later use
            }

            ViewBag.Category = GetCategory();
            ViewBag.EqpCode = GetEqpCode();
            ViewBag.Months = GetMonths();
            ViewBag.Terms = GetTerms();
            ViewBag.Dept = GetDept();
            ViewBag.Status = GetStatus();
            ViewBag.Division = GetDivision();
            ViewBag.IntExt = GetIntExt();
            return View("Edit", globalResultEQP);
        }


        [HttpPost]
        public IActionResult Edit(GlobalControllerClass model, IFormFile _pathIMG, IFormFile _pathDoc)
        {


            try
            {
                // Update the edited data in the ResultEQPController

                if (_pathIMG != null && _pathIMG.Length > 0)
                {
                    // Delete the previous image, if it exists
                    if (!string.IsNullOrEmpty(model.CalibrationResultEQP.fld_pathIMG))
                    {
                        string previousImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", model.CalibrationResultEQP.fld_pathIMG);
                        if (System.IO.File.Exists(previousImagePath))
                        {
                            System.IO.File.Delete(previousImagePath);
                        }
                    }

                    // Save the new image
                    string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"equipment"}-{model.CalibrationResultEQP.fld_ctrlNo}-{_pathIMG.FileName}";
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileNameIMG);

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        _pathIMG.CopyTo(fileStream);
                    }

                    model.CalibrationResultEQP.fld_pathIMG = uniqueFileNameIMG;
                }

                if (_pathDoc != null && _pathDoc.Length > 0)
                {
                    // Delete the previous document, if it exists
                    if (!string.IsNullOrEmpty(model.CalibrationResultEQP.fld_pathDoc))
                    {
                        string previousDocPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", model.CalibrationResultEQP.fld_pathDoc);
                        if (System.IO.File.Exists(previousDocPath))
                        {
                            System.IO.File.Delete(previousDocPath);
                        }
                    }

                    // Save the new document
                    string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"equipment"}-{model.CalibrationResultEQP.fld_ctrlNo}-{_pathDoc.FileName}";
                    string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", uniqueFileNameDoc);

                    using (var fileStream = new FileStream(docPath, FileMode.Create))
                    {
                        _pathDoc.CopyTo(fileStream);
                    }

                    model.CalibrationResultEQP.fld_pathDoc = uniqueFileNameDoc;
                }
            }
            catch(Exception ex)
            {

            }

                

                //_context.CalibrationResultEQP.Update(model.CalibrationResultEQP);
                _context.Attach(model.CalibrationResultEQP);
                _context.Entry(model.CalibrationResultEQP).State = EntityState.Modified;
                _context.Entry(model.CalibrationResultEQP).Property(f => f.fld_pathIMG).IsModified = _pathIMG != null;
                _context.Entry(model.CalibrationResultEQP).Property(f => f.fld_pathDoc).IsModified = _pathDoc != null;
                _context.SaveChanges();

            EquipmentRegistration equipmentRecord = _context.Equipment_table.FirstOrDefault(e => e.fld_ctrlNo == model.CalibrationResultEQP.fld_ctrlNo);

            // Retrieve the corresponding record from EquipmentMasterController
            var equipmentModel = _context.Equipment_table.FirstOrDefault(e => e.id == equipmentRecord.id);

                if (equipmentModel != null)
                {
                    // Update the similar data in EquipmentMasterController
                    equipmentModel.fld_codeNo = model.CalibrationResultEQP.fld_codeNo;
                    equipmentModel.fld_ctrlNo = model.CalibrationResultEQP.fld_ctrlNo;
                    equipmentModel.fld_division = equipmentModel.fld_division;
                    equipmentModel.fld_category = equipmentModel.fld_category;
                    equipmentModel.fld_code2 = equipmentModel.fld_code2;
                    equipmentModel.fld_eqpName = model.CalibrationResultEQP.fld_eqpName;
                    equipmentModel.fld_eqpModelNo = model.CalibrationResultEQP.fld_eqpModelNo;
                    equipmentModel.fld_serial = model.CalibrationResultEQP.fld_serial;
                    equipmentModel.fld_brand = model.CalibrationResultEQP.fld_brand;
                    equipmentModel.fld_term = model.CalibrationResultEQP.fld_term;
                    equipmentModel.fld_reqFunction = equipmentModel.fld_reqFunction;
                    equipmentModel.fld_passFail = model.CalibrationResultEQP.fld_passFail;
                    equipmentModel.fld_registrationDate = equipmentModel.fld_registrationDate;
                    equipmentModel.fld_imte = model.CalibrationResultEQP.fld_imte;
                    equipmentModel.fld_calibDate = DateTime.Parse(model.CalibrationResultEQP.fld_calibDate);
                    equipmentModel.fld_calibMonth = model.CalibrationResultEQP.fld_calibMonth;
                    equipmentModel.fld_calibYear = model.CalibrationResultEQP.fld_calibYear;
                    equipmentModel.fld_nextCalibDate = DateTime.Parse(model.CalibrationResultEQP.fld_nextCalibDate);
                    equipmentModel.fld_nextCalibMonth = model.CalibrationResultEQP.fld_nextCalibMonth;
                    equipmentModel.fld_nextCalibYear = model.CalibrationResultEQP.fld_nextCalibYear;
                    equipmentModel.fld_internalExternal = model.CalibrationResultEQP.fld_internalExternal;
                    equipmentModel.fld_supplierExternal = model.CalibrationResultEQP.fld_supplierExternal;
                    equipmentModel.fld_comment = model.CalibrationResultEQP.fld_comment;
                    equipmentModel.fld_appStandardEqp = model.CalibrationResultEQP.fld_appStandardEqp;
                    equipmentModel.fld_pathIMG = model.CalibrationResultEQP.fld_pathIMG;
                    equipmentModel.fld_pathDoc = model.CalibrationResultEQP.fld_pathDoc;
                    equipmentModel.fld_stat = model.CalibrationResultEQP.fld_stat;
                    equipmentModel.fld_withNCR = model.CalibrationResultEQP.fld_withNC;
                    equipmentModel.fld_withFailureReport = model.CalibrationResultEQP.fld_CalibFR;
                    equipmentModel.fld_withDisSus = model.CalibrationResultEQP.fld_calibDisSusForm;


                    _context.Equipment_table.Update(equipmentModel);
                }

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
