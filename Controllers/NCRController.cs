using Calibration_Management_System.Data;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;

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
                ncr = _context.NCR_table
                .OrderByDescending(x => x.id) // Assuming 'id' is the ID field
                .Take(0)
                .ToList();
            return View(ncr);
        }

        public IActionResult NCRLoadData2()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            int start = int.Parse(Request.Form["start"].FirstOrDefault());
            int length = int.Parse(Request.Form["length"].FirstOrDefault());

            // Get global search value
            string searchValue = Request.Form["search[value]"].FirstOrDefault();

            // Query the database based on start, length, filters, etc.
            var query = _context.NCR_table.Where(x => x.fld_contents != null);



            // Apply global search filter
            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(x =>
                    x.fld_nonConReportNo.Contains(searchValue) ||
                    x.fld_dateIssue.Contains(searchValue) ||
                    x.fld_ctrlNo.Contains(searchValue) ||
                    x.fld_IssueTo.Contains(searchValue) ||
                    x.fld_mainIncharge.Contains(searchValue) ||
                    x.fld_modelNo.Contains(searchValue) ||
                    x.fld_qty.Contains(searchValue) ||
                    x.fld_withDisposalForm.Contains(searchValue) ||
                    x.fld_contents.Contains(searchValue) ||
                    x.fld_dateCompleted.Contains(searchValue) ||
                    x.fld_status.Contains(searchValue) ||
                    x.fld_calibReportNo.Contains(searchValue) ||
                    x.fld_giveDisposeSuspendedForm.Contains(searchValue) ||
                    x.fld_givenTo.Contains(searchValue) ||
                    
                    x.fld_rcvDisposeSuspendedForm.Contains(searchValue)
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
                            query = query.Where(x => x.fld_nonConReportNo.Contains(getData));
                            break;
                        case 2: // Handle search for the second column
                            query = query.Where(x => x.fld_dateIssue.Contains(getData));
                            break;

                        case 3: // Handle search for the second column
                            query = query.Where(x => x.fld_ctrlNo.Contains(getData));
                            break;
                        case 4: // Handle search for the second column
                            query = query.Where(x => x.fld_IssueTo.Contains(getData));
                            break;
                        case 5: // Handle search for the second column
                            query = query.Where(x => x.fld_mainIncharge.Contains(getData));
                            break;
                        case 6: // Handle search for the second column
                            query = query.Where(x => x.fld_modelNo.Contains(getData));
                            break;
                        case 7: // Handle search for the second column
                            query = query.Where(x => x.fld_qty.Contains(getData));
                            break;
                        case 8: // Handle search for the second column
                            query = query.Where(x => x.fld_withDisposalForm.Contains(getData));
                            break;
                        case 9: // Handle search for the second column
                            query = query.Where(x => x.fld_contents.Contains(getData));
                            break;
                        case 10: // Handle search for the second column
                            query = query.Where(x => x.fld_dateCompleted.Contains(getData));
                            break;
                        case 11: // Handle search for the second column
                            query = query.Where(x => x.fld_status.Contains(getData));
                            break;
                        case 12: // Handle search for the second column
                            query = query.Where(x => x.fld_calibReportNo.Contains(getData));
                            break;
                        case 13: // Handle search for the second column
                            query = query.Where(x => x.fld_giveDisposeSuspendedForm.ToString().Contains(getData));
                            break;
                        case 14: // Handle search for the second column
                            query = query.Where(x => x.fld_givenTo.ToString().Contains(getData));
                            break;
                        case 15: // Handle search for the second column
                            query = query.Where(x => x.fld_rcvDisposeSuspendedForm.Contains(getData));
                            break;
                        
                            // Add cases for other columns here...
                    }
                }
            }

            var data = query.Skip(start).Take(length).ToList();
            var totalCount = query.Count();

            return Json(new { draw = draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = data });
        }


        public IActionResult ExportAllData()
        {
            var allData = _context.NCR_table.Where(x => x.fld_contents != null);

            // Create headers
            var headers = string.Join(",", typeof(NCR).GetProperties().Select(prop => prop.Name));

            // Create CSV data with headers
            var csvData = new StringBuilder();
            csvData.AppendLine(headers); // Add headers as the first line

            // Add rows of data
            foreach (var dataRow in allData)
            {
                var rowData = string.Join(",", typeof(NCR).GetProperties().Select(prop => prop.GetValue(dataRow, null)));
                csvData.AppendLine(rowData);
            }

            byte[] buffer = Encoding.UTF8.GetBytes(csvData.ToString());

            return File(buffer, "text/csv", "exported_data.csv");
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

        [Authorize(Roles = "Control Function,Admin-Calibration")]
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
