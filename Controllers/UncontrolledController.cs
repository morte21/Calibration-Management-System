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
            uncontrolled = _context.Uncontrolled_table
                .OrderByDescending(x => x.id) // Assuming 'id' is the ID field
                .Take(0)
                .ToList();
            return View(uncontrolled);
        }


        public IActionResult UNLoadData2()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            int start = int.Parse(Request.Form["start"].FirstOrDefault());
            int length = int.Parse(Request.Form["length"].FirstOrDefault());

            // Get global search value
            string searchValue = Request.Form["search[value]"].FirstOrDefault();

            // Query the database based on start, length, filters, etc.
            var query = _context.Uncontrolled_table.Where(x => x.fld_nameEquip != null );


            // Apply global search filter
            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(x =>
                    x.fld_nameEquip.Contains(searchValue) ||
                    x.fld_modelType.Contains(searchValue) ||
                    x.fld_serial.Contains(searchValue) ||
                    x.fld_maker.Contains(searchValue) ||
                    x.fld_reasonUncontrolled.Contains(searchValue) ||
                    x.fld_qty.Contains(searchValue) ||
                    x.fld_reqDate.Contains(searchValue) ||
                    x.fld_reqBy.Contains(searchValue) ||
                    x.fld_department.Contains(searchValue) ||

                    x.fld_commento.Contains(searchValue)
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
                            query = query.Where(x => x.fld_nameEquip.Contains(getData));
                            break;
                        case 2: // Handle search for the second column
                            query = query.Where(x => x.fld_modelType.Contains(getData));
                            break;

                        case 3: // Handle search for the second column
                            query = query.Where(x => x.fld_serial.Contains(getData));
                            break;
                        case 4: // Handle search for the second column
                            query = query.Where(x => x.fld_maker.Contains(getData));
                            break;
                        case 5: // Handle search for the second column
                            query = query.Where(x => x.fld_reasonUncontrolled.Contains(getData));
                            break;
                        case 6: // Handle search for the second column
                            query = query.Where(x => x.fld_qty.Contains(getData));
                            break;
                        case 7: // Handle search for the second column
                            query = query.Where(x => x.fld_reqDate.Contains(getData));
                            break;
                        case 8: // Handle search for the second column
                            query = query.Where(x => x.fld_reqBy.Contains(getData));
                            break;
                        case 9: // Handle search for the second column
                            query = query.Where(x => x.fld_department.Contains(getData));
                            break;
                        case 10: // Handle search for the second column
                            query = query.Where(x => x.fld_commento.Contains(getData));
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
            var allData = _context.Uncontrolled_table.Where(x => x.fld_nameEquip != null);

            // Create headers
            var headers = string.Join(",", typeof(Uncontrolled).GetProperties().Select(prop => prop.Name));

            // Create CSV data with headers
            var csvData = new StringBuilder();
            csvData.AppendLine(headers); // Add headers as the first line

            // Add rows of data
            foreach (var dataRow in allData)
            {
                var rowData = string.Join(",", typeof(Uncontrolled).GetProperties().Select(prop => prop.GetValue(dataRow, null)));
                csvData.AppendLine(rowData);
            }

            byte[] buffer = Encoding.UTF8.GetBytes(csvData.ToString());

            return File(buffer, "text/csv", "exported_data.csv");
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
