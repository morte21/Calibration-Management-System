using Calibration_Management_System.Data;
using Calibration_Management_System.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Calibration_Management_System.Controllers
{
    public class CalibScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EquipmentService _equipmentService;
        private readonly JigService _jigService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CalibScheduleController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, EquipmentService equipmentService, JigService jigService)
        {
            _context = context;
            _equipmentService = equipmentService;
            _jigService = jigService;
            _hostingEnvironment = hostingEnvironment;
        }



        public IActionResult Index()
        {
            ViewBag.Months = GetMonths();
            var model = new DateModel
            {
                SelectedDates = new List<DateTime>() // Initialize with an empty list
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DateModel model)
        {
            if (model.SelectedDates == null)
            {
                model.SelectedDates = new List<DateTime>(); // Initialize if null
            }

            // Process the selected dates here
            // Sort them from oldest to latest date
            var sortedDates = model.SelectedDates.OrderBy(d => d).ToList();

            // You can now use the sortedDates in your view or perform any other action as needed.

            return View(model);
        }

       


        public async Task<IActionResult> SearchDb(string selectType, string monthInput, string yearInput)
        {
            try
            {
                List<object> searchResults = new List<object>();

                if (selectType == "Equipment")
                {
                    // Fetch equipment data based on the date range
                    var equipmentData = await _equipmentService.GetEquipmentByMonthAndYear(monthInput, yearInput);
                    // Transform equipmentData into the desired format
                    foreach (var e in equipmentData)
                    {
                        // Find the corresponding selected date for this equipment data

                        searchResults.Add(new
                        {
                            //calibrationDate = calibrationDate, // Use the matching selected date
                            fld_calibDate = e.fld_calibDate,
                            fld_codeNo = e.fld_codeNo,
                            fld_ctrlNo = e.fld_ctrlNo,
                            fld_eqpName = e.fld_eqpName,
                            fld_eqpModelNo = e.fld_eqpModelNo,
                            fld_serial = e.fld_serial,
                            fld_brand = e.fld_brand,
                            fld_term = e.fld_term,
                            fld_reqFunction = e.fld_reqFunction,
                            fld_comment = e.fld_comment

                        });
                    }
                }
                else if (selectType == "Jig")
                {
                    // Fetch jig data based on the date range
                    var jigData = await _jigService.GetJigByMonthAndYear(monthInput, yearInput);
                    // Transform jigData into the desired format
                    foreach (var j in jigData)
                    {
                        // Find the corresponding selected date for this jig data
                        //var matchingDate = selectedDates.ToString();
                        searchResults.Add(new
                        {
                            //calibrationDate = matchingDate, // Use the matching selected date
                            fld_calibDate = j.fld_calibDate,
                            fld_ctrlNo = j.fld_ctrlNo,
                            fld_jigName = j.fld_jigName,
                            fld_drawingNo = j.fld_drawingNo,
                            fld_term = j.fld_term,
                            fld_reqFunction = j.fld_reqFunction,
                            fld_remarks = j.fld_remarks
                        });
                    }
                }

                // You can format and filter data as needed and convert it to a common format

                return Json(searchResults);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        public async Task<IActionResult> SearchData(string selectType, DateTime myDateInput1, DateTime myDateInput2)
        {
            try
            {
                List<object> searchResults = new List<object>();

                if (selectType == "Equipment")
                {
                    // Fetch equipment data based on the date range
                    var equipmentData = await _equipmentService.GetEquipmentDataBetweenDatesAsync(myDateInput1, myDateInput2);
                    // Transform equipmentData into the desired format
                    foreach (var e in equipmentData)
                    {
                        // Find the corresponding selected date for this equipment data

                        searchResults.Add(new
                        {
                            //calibrationDate = calibrationDate, // Use the matching selected date
                            fld_calibDate = e.fld_calibDate,
                            fld_codeNo = e.fld_codeNo,
                            fld_ctrlNo = e.fld_ctrlNo,
                            fld_eqpName = e.fld_eqpName,
                            fld_eqpModelNo = e.fld_eqpModelNo,
                            fld_serial = e.fld_serial,
                            fld_brand = e.fld_brand,
                            fld_term = e.fld_term,
                            fld_reqFunction = e.fld_reqFunction,
                            fld_comment = e.fld_comment
                        });
                    }
                }
                else if (selectType == "Jig")
                {
                    // Fetch jig data based on the date range
                    var jigData = await _jigService.GetJigDataBetweenDatesAsync(myDateInput1, myDateInput2);
                    // Transform jigData into the desired format
                    foreach (var j in jigData)
                    {
                        // Find the corresponding selected date for this jig data
                        //var matchingDate = selectedDates.ToString();
                        searchResults.Add(new
                        {
                            //calibrationDate = matchingDate, // Use the matching selected date
                            fld_calibDate = j.fld_calibDate,
                            fld_ctrlNo = j.fld_ctrlNo,
                            fld_jigName = j.fld_jigName,
                            fld_drawingNo = j.fld_drawingNo,
                            fld_term = j.fld_term,
                            fld_reqFunction = j.fld_reqFunction,
                            fld_remarks = j.fld_remarks
                        });
                    }
                }

                // You can format and filter data as needed and convert it to a common format

                return Json(searchResults);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
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



        // Action method for exporting to Excel

        [HttpPost]
        public IActionResult ExportToExcel(string selectType, string selectMonth, [FromBody] List<List<string>> tableData)
        {
            // Create a new workbook
            var workbook = new XLWorkbook();

            // Add a worksheet to the workbook
            var worksheet = workbook.Worksheets.Add("Calibration Data");

            // Define the header row with formatting
            var headerRow = worksheet.Row(1);
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            headerRow.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            headerRow.Height = 30;

            // Define column names based on the selected type
            string[] columnNames = null;
            if (selectType == "Equipment")
            {
                columnNames = new string[]
                {
                "CODE", "CONTROL NUMBER", "SCHEDULE", "EQUIPMENT NAME",
                "EQUIPMENT MODEL NO", "SERIAL", "NUMBER", "BRAND/MAKER",
                "TERM", "EMPLOYMENT PLACE", "CALIBRATION DUE DATE", "REMARKS"
                };
            }
            else if (selectType == "Jig")
            {
                columnNames = new string[]
                {
                "CODE", "CONTROL NUMBER", "SCHEDULE", "JIG NAME",
                "DRAWING NO", "TERM", "LOCATION", "CALIBRATION DUE DATE", "REMARKS"
                };
            }
            else
            {
                // Handle invalid selectType if needed
                return NotFound();
            }

            // Add column names to the header row
            for (int i = 1; i <= columnNames.Length; i++)
            {
                worksheet.Cell(1, i).Value = columnNames[i - 1];
                
            }

            // Add data to the worksheet
            int row = 2;
            foreach (var rowData in tableData)
            {
                int col = 1;
                foreach (var value in rowData)
                {
                    worksheet.Cell(row, col).Value = value;
                    col++;
                }
                row++;
            }

            // Format the cells in the data rows
            worksheet.Range(2, 1, row - 1, columnNames.Length).Style.Alignment.WrapText = true;

            // Merge cells for the title
            IXLRange titleRange = worksheet.Range(1, 1, 1, columnNames.Length);
            titleRange.Merge();
            titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            titleRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            titleRange.Style.Font.FontSize = 22;
            titleRange.Style.Font.FontName = "Times New Roman";

            // Set title text
            worksheet.Cell(1, 1).Value = $"Calibration {GetTypeName(selectType)} Notice for the Month of {GetMonthName(selectMonth)}";

            // Auto-fit columns for better visibility
            worksheet.Columns().AdjustToContents();

            // Save the workbook to a memory stream
            var stream = new System.IO.MemoryStream();
            workbook.SaveAs(stream);

            // Set the content type and file name for the response
            Response.Headers.Add("Content-Disposition", $"attachment; filename={GetFileName(selectType, selectMonth)}");
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        private string GetMonthName(string monthNumber)
        {
            return DateTime.ParseExact(monthNumber, "MM", System.Globalization.CultureInfo.InvariantCulture)
                .ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture);
        }

        private string GetTypeName(string selectType)
        {
            if (selectType == "Equipment")
            {
                return "Equipment";
            }
            else if (selectType == "Jig")
            {
                return "Jig";
            }
            else
            {
                // Handle invalid selectType if needed
                return "InvalidType";
            }
        }

        private string GetFileName(string selectType, string selectMonth)
        {
            if (selectType == "Equipment")
            {
                return $"{selectMonth}_Calibration_Equipment_Notice.xlsx";
            }
            else if (selectType == "Jig")
            {
                return $"{selectMonth}_Calibration_Jig_Notice.xlsx";
            }
            else
            {
                // Handle invalid selectType if needed
                return "Invalid_FileName.xlsx";
            }
        }



    }
}
