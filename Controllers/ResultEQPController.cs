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
            calibrationResults = _context.CalibrationResultEQP
                .OrderByDescending(x => x.id) // Assuming 'id' is the ID field
                .Take(0)
                .ToList();
            return View(calibrationResults);
        }

        public IActionResult ResultEQPLoadData2()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            int start = int.Parse(Request.Form["start"].FirstOrDefault());
            int length = int.Parse(Request.Form["length"].FirstOrDefault());

            // Get global search value
            string searchValue = Request.Form["search[value]"].FirstOrDefault();

            // Query the database based on start, length, filters, etc.
            var query = _context.CalibrationResultEQP.Where(x => x.fld_ctrlNo != null);

            // Apply global search filter
            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(x =>
                    x.fld_stat.Contains(searchValue) ||
                    x.fld_codeNo.Contains(searchValue) ||
                    x.fld_ctrlNo.Contains(searchValue) ||
                    x.calibrationdate.Contains(searchValue) ||
                    x.fld_eqpName.Contains(searchValue) ||
                    x.fld_eqpModelNo.Contains(searchValue) ||
                    x.fld_serial.Contains(searchValue) ||
                    x.fld_brand.Contains(searchValue) ||
                    x.fld_term.Contains(searchValue) ||
                    x.fld_reqFunction.Contains(searchValue) ||
                    x.fld_passFail.Contains(searchValue) ||
                    x.fld_imte.Contains(searchValue) ||
                    x.fld_calibDate.Contains(searchValue) ||
                    x.fld_calibMonth.Contains(searchValue) ||
                    x.fld_calibYear.Contains(searchValue) ||
                    x.fld_nextCalibDate.Contains(searchValue) ||
                    x.fld_nextCalibMonth.Contains(searchValue) ||
                    x.fld_nextCalibYear.Contains(searchValue) ||
                    x.fld_internalExternal.Contains(searchValue) ||
                    x.fld_supplierExternal.Contains(searchValue) ||
                    x.fld_comment.Contains(searchValue) ||
                    x.fld_appStandardEqp.Contains(searchValue) ||
                    x.fld_dateReturned.Contains(searchValue) ||
                    x.fld_withNC.Contains(searchValue) ||
                    x.fld_CalibFR.Contains(searchValue) ||
                    x.fld_calibDisSusForm.Contains(searchValue) ||
                    x.fld_withCalibResult.Contains(searchValue) ||
                    x.fld_incharge.Contains(searchValue) ||
                    x.fld_remarks.Contains(searchValue) ||
                    x.fld_changeSticker.Contains(searchValue) ||
                    x.fld_actualCalibDueDate.Contains(searchValue) ||
                    x.fld_dateRecv.Contains(searchValue) ||
                    x.fld_month.Contains(searchValue) ||
                    x.fld_year.Contains(searchValue)
                // ...other fields here
                );
            }

            // Fetch all search values for each column (tfoot)
            List<string> searchValuesTfoot = new List<string>();
            for (int i = 0; i < Request.Form.Keys.Count; i++)
            {
                string key = Request.Form.Keys.ElementAt(i);
                if (key.StartsWith("columns") && key.Contains("[search][value]"))
                {
                    searchValuesTfoot.Add(Request.Form[key].FirstOrDefault());
                }
            }

            // Apply column-wise search filters from tfoot in
            for (int i = 0; i < searchValuesTfoot.Count; i++)
            {
                if (!string.IsNullOrEmpty(searchValuesTfoot[i]))
                {
                    string getData = searchValuesTfoot[i];

                    // Adjust search logic for each column based on the index
                    switch (i)
                    {
                        case 1: // Handle search for the first column (adjust these cases based on your column order)
                            query = query.Where(x => x.fld_stat.Contains(getData));
                            break;
                        case 2: // Handle search for the second column
                            query = query.Where(x => x.fld_codeNo.Contains(getData));
                            break;

                        case 3: // Handle search for the second column
                            query = query.Where(x => x.fld_ctrlNo.Contains(getData));
                            break;
                        case 4: // Handle search for the second column
                            query = query.Where(x => x.calibrationdate.Contains(getData));
                            break;
                        case 5: // Handle search for the second column
                            query = query.Where(x => x.fld_eqpName.Contains(getData));
                            break;
                        case 6: // Handle search for the second column
                            query = query.Where(x => x.fld_eqpModelNo.Contains(getData));
                            break;
                        case 7: // Handle search for the second column
                            query = query.Where(x => x.fld_serial.Contains(getData));
                            break;
                        case 8: // Handle search for the second column
                            query = query.Where(x => x.fld_brand.Contains(getData));
                            break;
                        case 9: // Handle search for the second column
                            query = query.Where(x => x.fld_term.Contains(getData));
                            break;
                        case 10: // Handle search for the second column
                            query = query.Where(x => x.fld_reqFunction.Contains(getData));
                            break;
                        case 11: // Handle search for the second column
                            query = query.Where(x => x.fld_passFail.Contains(getData));
                            break;
                        case 12: // Handle search for the second column
                            query = query.Where(x => x.fld_imte.Contains(getData));
                            break;
                        case 13: // Handle search for the second column
                            query = query.Where(x => x.fld_calibDate.ToString().Contains(getData));
                            break;
                        case 14: // Handle search for the second column
                            query = query.Where(x => x.fld_calibMonth.ToString().Contains(getData));
                            break;
                        case 15: // Handle search for the second column
                            query = query.Where(x => x.fld_calibYear.Contains(getData));
                            break;
                        case 16: // Handle search for the second column
                            query = query.Where(x => x.fld_nextCalibDate.Contains(getData));
                            break;
                        case 17: // Handle search for the second column
                            query = query.Where(x => x.fld_nextCalibMonth.ToString().Contains(getData));
                            break;
                        case 18: // Handle search for the second column
                            query = query.Where(x => x.fld_nextCalibYear.Contains(getData));
                            break;
                        case 19: // Handle search for the second column
                            query = query.Where(x => x.fld_internalExternal.Contains(getData));
                            break;
                        case 20: // Handle search for the second column
                            query = query.Where(x => x.fld_supplierExternal.Contains(getData));
                            break;
                        case 21: // Handle search for the second column
                            query = query.Where(x => x.fld_comment.Contains(getData));
                            break;
                        case 22: // Handle search for the second column
                            query = query.Where(x => x.fld_appStandardEqp.Contains(getData));
                            break;
                        case 25: // Handle search for the second column
                            query = query.Where(x => x.fld_dateReturned.Contains(getData));
                            break;
                        case 26: // Handle search for the second column
                            query = query.Where(x => x.fld_withNC.Contains(getData));
                            break;
                        case 27: // Handle search for the second column
                            query = query.Where(x => x.fld_CalibFR.Contains(getData));
                            break;
                        case 28: // Handle search for the second column
                            query = query.Where(x => x.fld_calibDisSusForm.Contains(getData));
                            break;
                        case 29: // Handle search for the second column
                            query = query.Where(x => x.fld_withCalibResult.Contains(getData));
                            break;
                        case 30: // Handle search for the second column
                            query = query.Where(x => x.fld_incharge.Contains(getData));
                            break;
                        case 31: // Handle search for the second column
                            query = query.Where(x => x.fld_remarks.Contains(getData));
                            break;
                        case 32: // Handle search for the second column
                            query = query.Where(x => x.fld_changeSticker.Contains(getData));
                            break;
                        case 33: // Handle search for the second column
                            query = query.Where(x => x.fld_actualCalibDueDate.Contains(getData));
                            break;
                        case 34: // Handle search for the second column
                            query = query.Where(x => x.fld_dateRecv.Contains(getData));
                            break;
                        case 35: // Handle search for the second column
                            query = query.Where(x => x.fld_month.Contains(getData));
                            break;
                        case 36: // Handle search for the second column
                            query = query.Where(x => x.fld_year.Contains(getData));
                            break;
                            // Add cases for other columns here...
                    }
                }
            }

            var data = query.Skip(start).Take(length).ToList();
            var totalCount = query.Count();

            return Json(new { draw = draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = data });
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

            _context.Attach(equipmentModel);
            _context.Entry(equipmentModel).State = EntityState.Modified;
            _context.Entry(equipmentModel).Property(f => f.fld_pathIMG).IsModified = _pathIMG != null;
            _context.Entry(equipmentModel).Property(f => f.fld_pathDoc).IsModified = _pathDoc != null;
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
