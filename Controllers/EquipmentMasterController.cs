using Calibration_Management_System.Data;
using Calibration_Management_System.Migrations;
using Calibration_Management_System.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
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
            //List<EquipmentRegistration> equipmentRegistrations;
            //equipmentRegistrations = _context.Equipment_table.ToList();
            //equipmentRegistrations = _context.Equipment_table.OrderByDescending(x => x.id).ToList();

            //SORT THE TABLE
            //equipmentRegistrations = _context.Equipment_table.Where(x => x.fld_passFail == "PASS" && x.fld_stat == "OK").ToList();

            List<EquipmentRegistration> equipmentRegistrations;
            equipmentRegistrations = _context.Equipment_table
                .Where(x => x.fld_passFail == "PASS" && x.fld_stat == "OK")
                .OrderByDescending(x => x.id) // Assuming 'id' is the ID field
                .Take(0)
                .ToList();


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

        public IActionResult masterRegLoadData()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            int start = int.Parse(Request.Form["start"].FirstOrDefault());
            int length = int.Parse(Request.Form["length"].FirstOrDefault());

            // Get global search value
            string searchValue = Request.Form["search[value]"].FirstOrDefault();

            // Query the database based on start, length, filters, etc.
            var query = _context.Equipment_table.Where(x => x.fld_passFail == "PASS" && x.fld_stat == "OK");


            // Apply global search filter
            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(x =>
                    x.fld_codeNo.Contains(searchValue) ||
                    x.fld_ctrlNo.Contains(searchValue) ||
                    x.fld_division.Contains(searchValue) ||
                    x.fld_category.Contains(searchValue) ||
                    x.fld_code2.Contains(searchValue) ||
                    x.fld_eqpName.Contains(searchValue) ||
                    x.fld_eqpModelNo.Contains(searchValue) ||
                    x.fld_serial.Contains(searchValue) ||
                    x.fld_brand.Contains(searchValue) ||
                    x.fld_term.Contains(searchValue) ||
                    x.fld_reqFunction.Contains(searchValue) ||
                    x.fld_passFail.Contains(searchValue) ||
                    x.fld_registrationDate.ToString().Contains(searchValue) ||
                    x.fld_calibDate.ToString().Contains(searchValue) ||
                    x.fld_calibMonth.Contains(searchValue) ||
                    x.fld_calibYear.Contains(searchValue) ||
                    x.fld_nextCalibDate.ToString().Contains(searchValue) ||
                    x.fld_nextCalibMonth.Contains(searchValue) ||
                    x.fld_nextCalibYear.Contains(searchValue) ||
                    x.fld_internalExternal.Contains(searchValue) ||
                    x.fld_supplierExternal.Contains(searchValue) ||
                    x.fld_comment.Contains(searchValue) ||
                    x.fld_appStandardEqp.Contains(searchValue) ||
                    x.fld_pathIMG.Contains(searchValue) ||
                    x.fld_pathDoc.Contains(searchValue) ||
                    x.fld_stat.Contains(searchValue) ||
                    x.fld_calibResult.Contains(searchValue)
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
                            query = query.Where(x => x.fld_codeNo.Contains(getData));
                            break;
                        case 2: // Handle search for the second column
                            query = query.Where(x => x.fld_ctrlNo.Contains(getData));
                            break;

                        case 3: // Handle search for the second column
                            query = query.Where(x => x.fld_division.Contains(getData));
                            break;
                        case 4: // Handle search for the second column
                            query = query.Where(x => x.fld_category.Contains(getData));
                            break;
                        case 5: // Handle search for the second column
                            query = query.Where(x => x.fld_code2.Contains(getData));
                            break;
                        case 6: // Handle search for the second column
                            query = query.Where(x => x.fld_eqpName.Contains(getData));
                            break;
                        case 7: // Handle search for the second column
                            query = query.Where(x => x.fld_eqpModelNo.Contains(getData));
                            break;
                        case 8: // Handle search for the second column
                            query = query.Where(x => x.fld_serial.Contains(getData));
                            break;
                        case 9: // Handle search for the second column
                            query = query.Where(x => x.fld_brand.Contains(getData));
                            break;
                        case 10: // Handle search for the second column
                            query = query.Where(x => x.fld_term.Contains(getData));
                            break;
                        case 11: // Handle search for the second column
                            query = query.Where(x => x.fld_reqFunction.Contains(getData));
                            break;
                        case 12: // Handle search for the second column
                            query = query.Where(x => x.fld_passFail.Contains(getData));
                            break;
                        case 13: // Handle search for the second column
                            query = query.Where(x => x.fld_registrationDate.ToString().Contains(getData));
                            break;
                        case 14: // Handle search for the second column
                            query = query.Where(x => x.fld_calibDate.ToString().Contains(getData));
                            break;
                        case 15: // Handle search for the second column
                            query = query.Where(x => x.fld_calibMonth.Contains(getData));
                            break;
                        case 16: // Handle search for the second column
                            query = query.Where(x => x.fld_calibYear.Contains(getData));
                            break;
                        case 17: // Handle search for the second column
                            query = query.Where(x => x.fld_nextCalibDate.ToString().Contains(getData));
                            break;
                        case 18: // Handle search for the second column
                            query = query.Where(x => x.fld_nextCalibMonth.Contains(getData));
                            break;
                        case 19: // Handle search for the second column
                            query = query.Where(x => x.fld_nextCalibYear.Contains(getData));
                            break;
                        case 20: // Handle search for the second column
                            query = query.Where(x => x.fld_internalExternal.Contains(getData));
                            break;
                        case 21: // Handle search for the second column
                            query = query.Where(x => x.fld_supplierExternal.Contains(getData));
                            break;
                        case 22: // Handle search for the second column
                            query = query.Where(x => x.fld_comment.Contains(getData));
                            break;
                        case 23: // Handle search for the second column
                            query = query.Where(x => x.fld_appStandardEqp.Contains(getData));
                            break;
                        case 24: // Handle search for the second column
                            query = query.Where(x => x.fld_pathIMG.Contains(getData));
                            break;
                        case 25: // Handle search for the second column
                            query = query.Where(x => x.fld_pathDoc.Contains(getData));
                            break;
                        case 26: // Handle search for the second column
                            query = query.Where(x => x.fld_stat.Contains(getData));
                            break;
                        case 27: // Handle search for the second column
                            query = query.Where(x => x.fld_calibResult.Contains(getData));
                            break;
                            // Add cases for other columns here...
                    }
                }
            }

            // Perform data filtering and pagination
            var data = query.Skip(start).Take(length).ToList();
            var totalCount = query.Count();

            return Json(new { draw = draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = data });
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
