using Calibration_Management_System.Data;
using Calibration_Management_System.Migrations;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentFormat.OpenXml.Office2010.Excel;
using Humanizer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Calibration_Management_System.Controllers
{
    public class CalibrationNoticeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CalibrationNoticeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        public IActionResult Index()
        {
            List<CalibrationNotice> calibNotice;

            calibNotice = _context.CalibrationNotice_table.OrderByDescending(x => x.fld_dateCreated).ToList();

            return View(calibNotice);
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Create()
        {
            CalibrationNotice calibNotice = new CalibrationNotice();
            return View(calibNotice);
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpPost]
        public IActionResult Create(CalibrationNotice calibNotice, IFormFile _pathEQP, IFormFile _pathJIG)
        {
            //EQP
            if (_pathEQP != null && _pathEQP.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"equipment"}-{"schedule"}-{_pathEQP.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Equipment", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathEQP.CopyTo(fileStream);
                }

                calibNotice.fld_pathEQP = uniqueFileNameIMG;
            }

            //JIG
            if (_pathJIG != null && _pathJIG.Length > 0)
            {
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"jig"}-{"schedule"}-{_pathJIG.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Jig", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathJIG.CopyTo(fileStream);
                }

                calibNotice.fld_pathJIG = uniqueFileNameDoc;
            }

            _context.CalibrationNotice_table.Add(calibNotice);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin-Calibration")]
        [HttpGet]
        public IActionResult Approval(int id)
        {
            CalibrationNotice calibNotice = _context.CalibrationNotice_table.FirstOrDefault(r => r.Id == id);
;
            return View("Approval", calibNotice);
        }

        [HttpPost]
        public IActionResult Approval(CalibrationNotice calibNotice, IFormFile _pathEQP, IFormFile _pathJIG)
        {

            if (_pathEQP != null && _pathEQP.Length > 0)
            {
                // Delete the previous image, if it exists
                if (!string.IsNullOrEmpty(calibNotice.fld_pathEQP))
                {
                    string previousImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Equipment", calibNotice.fld_pathEQP);
                    if (System.IO.File.Exists(previousImagePath))
                    {
                        System.IO.File.Delete(previousImagePath);
                    }
                }

                // Save the new image
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"equipment"}-{"schedule"}-{_pathEQP.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Equipment", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathEQP.CopyTo(fileStream);
                }


                calibNotice.fld_pathEQP = uniqueFileNameIMG;


            }




            if (_pathJIG != null && _pathJIG.Length > 0)
            {
                // Delete the previous document, if it exists
                if (!string.IsNullOrEmpty(calibNotice.fld_pathJIG))
                {
                    string previousDocPath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Jig", calibNotice.fld_pathJIG);
                    if (System.IO.File.Exists(previousDocPath))
                    {
                        System.IO.File.Delete(previousDocPath);
                    }
                }

                // Save the new document
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"jig"}-{"schedule"}-{_pathJIG.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Jig", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathJIG.CopyTo(fileStream);
                }


                calibNotice.fld_pathJIG = uniqueFileNameDoc;


            }


            _context.Attach(calibNotice);
            _context.Entry(calibNotice).State = EntityState.Modified;
            _context.Entry(calibNotice).Property(f => f.fld_pathEQP).IsModified = _pathEQP != null;
            _context.Entry(calibNotice).Property(f => f.fld_pathJIG).IsModified = _pathJIG != null;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CalibrationNotice calibNotice = _context.CalibrationNotice_table.FirstOrDefault(r => r.Id == id);
            ;
            return View("Edit", calibNotice);
        }

        [HttpPost]
        public IActionResult Edit(CalibrationNotice calibNotice, IFormFile _pathEQP, IFormFile _pathJIG)
        {

            if (_pathEQP != null && _pathEQP.Length > 0)
            {
                // Delete the previous image, if it exists
                if (!string.IsNullOrEmpty(calibNotice.fld_pathEQP))
                {
                    string previousImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Equipment", calibNotice.fld_pathEQP);
                    if (System.IO.File.Exists(previousImagePath))
                    {
                        System.IO.File.Delete(previousImagePath);
                    }
                }

                // Save the new image
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"equipment"}-{"schedule"}-{_pathEQP.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Equipment", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathEQP.CopyTo(fileStream);
                }


                calibNotice.fld_pathEQP = uniqueFileNameIMG;


            }




            if (_pathJIG != null && _pathJIG.Length > 0)
            {
                // Delete the previous document, if it exists
                if (!string.IsNullOrEmpty(calibNotice.fld_pathJIG))
                {
                    string previousDocPath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Jig", calibNotice.fld_pathJIG);
                    if (System.IO.File.Exists(previousDocPath))
                    {
                        System.IO.File.Delete(previousDocPath);
                    }
                }

                // Save the new document
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"jig"}-{"schedule"}-{_pathJIG.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice\\Jig", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathJIG.CopyTo(fileStream);
                }


                calibNotice.fld_pathJIG = uniqueFileNameDoc;


            }


            _context.Attach(calibNotice);
            _context.Entry(calibNotice).State = EntityState.Modified;
            _context.Entry(calibNotice).Property(f => f.fld_pathEQP).IsModified = _pathEQP != null;
            _context.Entry(calibNotice).Property(f => f.fld_pathJIG).IsModified = _pathJIG != null;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Notification(int id)
        {
            //get global value from other controller
            GlobalControllerClass globalControllerClass = new GlobalControllerClass();
            ViewBag.Email = GetEmail();
            globalControllerClass.CalibrationNoticeData = _context.CalibrationNotice_table.Where(a => a.Id == id).FirstOrDefault(); 
    
            return View(globalControllerClass);
        }

       
        [HttpPost]
        public IActionResult SendEmailNotification( string[] getEmailTo, string[] getEmailCc)
        {
            string HTML = @"<!DOCTYPE html>
                                <html>
                                <head>
                                    <title></title>
                                    <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"" />
                                    <meta content=""width=device-width, initial-scale=1.0"" name=""viewport"" /><!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]--><!--[if !mso]><!-->
                                    <link href=""https://fonts.googleapis.com/css?family=Montserrat"" rel=""stylesheet"" type=""text/css"" />
                                    <link href=""https://fonts.googleapis.com/css?family=Playfair+Display"" rel=""stylesheet"" type=""text/css"" /><!--<![endif]-->
                                    <style>
                                        * {
                                            box-sizing: border-box;
                                        }

                                        body {
                                            margin: 0;
                                            padding: 0;
                                        }

                                        a[x-apple-data-detectors] {
                                            color: inherit !important;
                                            text-decoration: inherit !important;
                                        }

                                        #MessageViewBody a {
                                            color: inherit;
                                            text-decoration: none;
                                        }

                                        p {
                                            line-height: inherit
                                        }

                                        .desktop_hide,
                                        .desktop_hide table {
                                            /* mso-hide: all;*/
                                            display: none;
                                            max-height: 0px;
                                            overflow: hidden;
                                        }

                                        .image_block img + div {
                                            display: none;
                                        }
                                    </style>
                                </head>
                                <body style=""background-color: #e3e3e3; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nl-container"" role=""presentation"" style=""background-color: #e3e3e3;"" width=""100%"">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-1"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row-content stack"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #1e1e1e; color: #000000; width: 680px;"" width=""680"">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class=""column column-1"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"" width=""100%"">
                                                                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""heading_block block-1"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                                                                                        <tr>
                                                                                            <td class=""pad"" style=""width:100%;text-align:center;"">
                                                                                                <h1 style=""margin: 0; color: #ffffff; font-size: 11px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; line-height: 120%; text-align: center; direction: ltr; font-weight: 700; letter-spacing: normal; margin-top: 0; margin-bottom: 0;"">****THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL****</h1>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-2"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row-content stack"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; background-position: top center; color: #000000; width: 680px;"" width=""680"">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class=""column column-1"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-left: 60px; padding-right: 60px; padding-top: 30px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"" width=""100%"">
                                                                                    <div class=""spacer_block block-1"" style=""height:30px;line-height:30px;font-size:1px;""> </div>
                                                                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""heading_block block-2"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                                                                                        <tr>
                                                                                            <td class=""pad"" style=""text-align:center;width:100%;"">
                                                                                                <h2 style=""margin: 0; color: #000000; direction: ltr; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; font-size: 16px; font-weight: normal; letter-spacing: 1px; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;""><span class=""tinyMce-placeholder"">AUTOMATIC EMAIL</span></h2>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""heading_block block-3"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                                                                                        <tr>
                                                                                            <td class=""pad"" style=""padding-bottom:20px;padding-top:10px;text-align:center;width:100%;"">
                                                                                                <h1 style=""margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 15px; font-weight: normal; letter-spacing: normal; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;"">Calibration Notice of Equipment and Jigs for the Month of {calibMonth}</h1>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                                                                                        <tr>
                                                                                            <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                                                                                                <div style=""font-family: sans-serif"">
                                                                                                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5;"">

                                                                                                        <p style=""margin: 0; font-size: 10px; text-align: left; mso-line-height-alt: 21px;"">Please refer to the attachment of calibration notice for the month of {calibMonth}.</p>
                                                                                                        <p style=""margin: 0; font-size: 10px; text-align: left; mso-line-height-alt: 18px;"">Please prepare all your equipment and jigs that is subject for calibration for the month of {calibMonth}. </p>
                                                                                                        <p style=""margin: 0; font-size: 10px; text-align: left; mso-line-height-alt: 21px;"">
                                                                                                            Reminders:
                                                                                                            <br />1. All equipment and jigs are required to submit/bring in 3D Room except for equipment that are installed/permanently fixed to its process area.
                                                                                                            <br />2. All equipment/jigs that are scheduled for calibration but not submitted to control function 2 DAYS after the scheduled date, will be declared as MISSING.
                                                                                                            <br />3. All equipment should be using their own adapter with same brand and model. Usage of imitative adapter brand is strictly prohibited and will not be received by the control function.
                                                                                                            <br />4. Cleanliness of equipment/jigs shall be maintained.5. All equipment subject for calibration shall be submitted at 3D Room until 11AM only on its Calibration Schedule. This is to avoid delays on both the control and using function.
                                                                                                        </p>
                                                                                                        <hr />

                                                                                                        <p style=""margin: 0; font-size: 10px; text-align: left; mso-line-height-alt: 21px;"">
                                                                                                            According to PGGY 63002:
                                                                                                            <br />&nbsp;&nbsp;3.0 Duties of the Using Function
                                                                                                            <br />&nbsp;&nbsp;&nbsp;&nbsp;3.2 Maintenance
                                                                                                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.2.1 Make sure that the expiration date of the measuring equipment has not past it’s due before using.
                                                                                                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.2.2 Let the control function perform the periodic calibrations in accordance with the ‘Calibration Record/ Measuring Equipment’s Master List’ (Form 7), which gives the notice of the expiration date.
                                                                                                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.2.3 Fill up the “Request Form for the Change of Using Function Code No.’ (Form 16) in case there’s a change in the using function of the measuring equipment.
                                                                                                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.2.4 Perform maintenance to prevent contamination and rust that can impair precision and proper function.
                                                                                                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.2.5 Retain the user's guides and catalogs, etc. of the measuring equipment.
                                                                                                            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3.2.6 Always check the battery status of the equipment before using it. Make sure that all equipment that uses battery is in good power condition.

                                                                                                        </p>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-5"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                                                                                        <tr>
                                                                                            <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                                                                                                <div style=""font-family: sans-serif"">
                                                                                                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5;"">
                                                                                                        <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">For your information and guidance.</span><br /><span style=""font-size:9px;"">Any concerns and clarification kindly inform the undersigned.</span><br /><span style=""font-size:9px;""><a href=""mailto:sdp-qacalibration@sanyodenki.com"" style=""text-decoration: underline; color: #e5af88;"">sdp-qacalibration@sanyodenki.com</a></span></p>
                                                                                                        <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">Local number: 109</span></p>
                                                                                                        <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">SANYO DENKI Philippines Inc.</span><br /><span style=""font-size:9px;"">Calibration System Automatic Email Notification</span></p>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row row-3"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""row-content stack"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 680px;"" width=""680"">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class=""column column-1"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"" width=""100%"">
                                                                                    <div class=""spacer_block block-1"" style=""height:30px;line-height:30px;font-size:1px;""> </div>
                                                                                    <table border=""0"" cellpadding=""10"" cellspacing=""0"" class=""social_block block-2"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                                                                                        <tr>
                                                                                            <td class=""pad"">
                                                                                                <div align=""center"" class=""alignment"">

                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-3"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                                                                                        <tr>
                                                                                            <td class=""pad"" style=""padding-bottom:5px;padding-top:5px;"">
                                                                                                <div style=""font-family: sans-serif"">
                                                                                                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #393d47; line-height: 1.5;"">
                                                                                                        <p style=""margin: 0; font-size: 14px; text-align: center; mso-line-height-alt: 21px;""><span style=""font-size:14px;color:#999999;"">QUALITY ASSURANCE 1 - SYSTEM AND MACHINE DEVELOPMENT</span></p>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table border=""0"" cellpadding=""30"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                                                                                        <tr>
                                                                                            <td class=""pad"">
                                                                                                <div style=""font-family: sans-serif"">
                                                                                                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #393d47; line-height: 1.5;"">
                                                                                                        <p style=""margin: 0; font-size: 10px; text-align: center; mso-line-height-alt: 15px;""><span style=""font-size:10px;""><span style=""""><span style=""color:#999999;""> <br /></span></span><span style=""color:#999999;"">© 2023 Sanyo Denki Philippines. All Rights Reserved.</span></span></p>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                </body>
                                </html>";
            

            
            var calibrationNotice = _context.CalibrationNotice_table.FirstOrDefault();
            // Replace placeholders with actual values
            string getMonthName = calibrationNotice.fld_calibMonth; ;

            var calibMonth = GetMonthName(getMonthName);
            //228
            HTML = HTML.Replace("{calibMonth}", calibMonth);

            // get path of the attachment
            // Get the root path of your web application
            string webRootPath = _webHostEnvironment.WebRootPath; // _hostingEnvironment is an instance of IHostingEnvironment

            // Construct the full file path
            string filePath1 = Path.Combine(webRootPath, "CalibrationNotice", "Equipment", calibrationNotice.fld_pathEQP);
            string filePath2 = Path.Combine(webRootPath, "CalibrationNotice", "Jig", calibrationNotice.fld_pathJIG);

            // Now you can use filePath in your attachment
            Attachment attachment1 = new Attachment(filePath1);
            Attachment attachment2 = new Attachment(filePath2);

            // Set the file names for the attachments (optional)
            attachment1.Name = "Calibration_Equipment_Notice.xlsx"; // Specify the desired new file name
            attachment2.Name = "Calibration_Jig_Notice.xlsx"; // Specify the desired new file name

            MailMessage message = new MailMessage();
            message.Subject = "Calibration System - Calibration Schedule Notification";
            message.IsBodyHtml = true;
            message.From = (new MailAddress("sdp.system@outlook.ph", "Calibration System"));
            message.Priority = MailPriority.High;
            message.Body = HTML;

            // Add an attachment
            message.Attachments.Add(attachment1);
            message.Attachments.Add(attachment2);

            ////To
            //message.To.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));
            //message.To.Add(new MailAddress("jason.casupanan@sanyodenki.com"));

            ////CC
            //message.CC.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));
            //message.CC.Add(new MailAddress("jason.casupanan@sanyodenki.com"));
            getEmailTo.ToString();


            // Add email addresses to the 'To' list
            if (getEmailTo != null)
            {
                foreach (string toEmail in getEmailTo)
                {
                    message.To.Add(toEmail);
                }
            }

            // Add email addresses to the 'CC' list
            if (getEmailCc != null)
            {
                foreach (string ccEmail in getEmailCc)
                {
                    message.CC.Add(ccEmail);
                }
            }


            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);



            return RedirectToAction("Notification", calibrationNotice);
        }

        private string GetMonthName(string monthNumber)
        {
            return DateTime.ParseExact(monthNumber, "MM", System.Globalization.CultureInfo.InvariantCulture)
                .ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture);
        }

        [HttpPost]
        public ActionResult UploadExcelToDatabase(int id, string eqpFileName, string jigFileName, int editId, string monthValue, string yearValue)
        {
            try
            {
               
                // Construct the full file paths based on the root directory
                string eqpFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice", "Equipment", eqpFileName);
                string jigFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "CalibrationNotice", "Jig", jigFileName);

                Console.Write(eqpFullPath);
                Console.Write(jigFullPath);
                //// Download Excel files from URLs using ClosedXML
                //var eqpWorkbook = new XLWorkbook(new MemoryStream(new WebClient().DownloadData(eqpFullPath)));
                //var jigWorkbook = new XLWorkbook(new MemoryStream(new WebClient().DownloadData(jigFullPath)));

                // Download Excel files from file paths using ClosedXML
                var eqpWorkbook = new XLWorkbook(eqpFullPath);
                var jigWorkbook = new XLWorkbook(jigFullPath);

                // Initialize DataTables for Eqp and Jig data
                var eqpDataTable = new DataTable();
                var jigDataTable = new DataTable();
                Console.Write(eqpDataTable);
                Console.Write(jigDataTable);

                // Customize column mappings
                
                eqpDataTable.Columns.Add("calibrationdate", typeof(string));
                eqpDataTable.Columns.Add("fld_actualCalibDueDate", typeof(string));
                eqpDataTable.Columns.Add("fld_codeNo", typeof(string));
                eqpDataTable.Columns.Add("fld_ctrlNo", typeof(string));
                eqpDataTable.Columns.Add("fld_eqpName", typeof(string));
                eqpDataTable.Columns.Add("fld_eqpModelNo", typeof(string));
                eqpDataTable.Columns.Add("fld_serial", typeof(string));
                eqpDataTable.Columns.Add("fld_brand", typeof(string));
                eqpDataTable.Columns.Add("fld_term", typeof(string));
                eqpDataTable.Columns.Add("fld_reqFunction", typeof(string));
                eqpDataTable.Columns.Add("fld_remarks", typeof(string));

                eqpDataTable.Columns.Add("fld_passFail", typeof(string));
                eqpDataTable.Columns.Add("fld_imte", typeof(string));
                eqpDataTable.Columns.Add("fld_calibDate", typeof(string));
                eqpDataTable.Columns.Add("fld_calibMonth", typeof(string));
                eqpDataTable.Columns.Add("fld_calibYear", typeof(string));
                eqpDataTable.Columns.Add("fld_nextCalibDate", typeof(string));
                eqpDataTable.Columns.Add("fld_nextCalibMonth", typeof(string));
                eqpDataTable.Columns.Add("fld_nextCalibYear", typeof(string));
                eqpDataTable.Columns.Add("fld_internalExternal", typeof(string));
                eqpDataTable.Columns.Add("fld_supplierExternal", typeof(string));
                eqpDataTable.Columns.Add("fld_comment", typeof(string));
                eqpDataTable.Columns.Add("fld_appStandardEqp", typeof(string));
                eqpDataTable.Columns.Add("fld_pathIMG", typeof(string));
                eqpDataTable.Columns.Add("fld_pathDoc", typeof(string));
                eqpDataTable.Columns.Add("fld_stat", typeof(string));
                eqpDataTable.Columns.Add("fld_dateReturned", typeof(string));
                eqpDataTable.Columns.Add("fld_withNC", typeof(string));
                eqpDataTable.Columns.Add("fld_CalibFR", typeof(string));
                eqpDataTable.Columns.Add("fld_calibDisSusForm", typeof(string));
                eqpDataTable.Columns.Add("fld_withCalibResult", typeof(string));
                eqpDataTable.Columns.Add("fld_incharge", typeof(string));
                
                eqpDataTable.Columns.Add("fld_changeSticker", typeof(string));
                eqpDataTable.Columns.Add("fld_dateRecv", typeof(string));
                eqpDataTable.Columns.Add("idd", typeof(string));
                eqpDataTable.Columns.Add("fld_month", typeof(string)); /*Data of this is from id = "monthUpload"*/
                eqpDataTable.Columns.Add("fld_year", typeof(string)); /*Data of this is from id = "yearUpload"*/
                




                jigDataTable.Columns.Add("calibrationdate", typeof(string));
                jigDataTable.Columns.Add("fld_actualCalibDueDate", typeof(string));
                
                jigDataTable.Columns.Add("fld_ctrlNo", typeof(string));
                jigDataTable.Columns.Add("fld_jigName", typeof(string));
                jigDataTable.Columns.Add("fld_drawingNo", typeof(string));
                jigDataTable.Columns.Add("fld_term", typeof(string));
                jigDataTable.Columns.Add("fld_reqFunction", typeof(string));
                jigDataTable.Columns.Add("fld_remarks", typeof(string));

                jigDataTable.Columns.Add("fld_passfail", typeof(string));
                jigDataTable.Columns.Add("fld_imte", typeof(string));
                jigDataTable.Columns.Add("fld_dateRecv", typeof(string));
                jigDataTable.Columns.Add("fld_calibDate", typeof(string));
                jigDataTable.Columns.Add("fld_calibMonth", typeof(string));
                jigDataTable.Columns.Add("fld_calibYear", typeof(string));
                jigDataTable.Columns.Add("fld_nextCalibDate", typeof(string));
                jigDataTable.Columns.Add("fld_nextCalibMonth", typeof(string));
                jigDataTable.Columns.Add("fld_nextCalibYear", typeof(string));
                jigDataTable.Columns.Add("fld_dateReturned", typeof(string));
                jigDataTable.Columns.Add("fld_internalExternal", typeof(string));
                jigDataTable.Columns.Add("fld_withNC", typeof(string));
                jigDataTable.Columns.Add("fld_CalibFR", typeof(string));
                jigDataTable.Columns.Add("fld_calibDisSusForm", typeof(string));
                jigDataTable.Columns.Add("fld_withCalibResult", typeof(string));
                jigDataTable.Columns.Add("fld_pathDoc", typeof(string));
                jigDataTable.Columns.Add("fld_pathIMG", typeof(string));
                jigDataTable.Columns.Add("fld_incharge", typeof(string));
                
                jigDataTable.Columns.Add("fld_changeSticker", typeof(string));
                jigDataTable.Columns.Add("fld_codeNo", typeof(string));
                jigDataTable.Columns.Add("idd", typeof(string));
                jigDataTable.Columns.Add("fld_month", typeof(string)); /*Data of this is from id = "monthUpload"*/
                jigDataTable.Columns.Add("fld_year", typeof(string)); /*Data of this is from id = "yearUpload"*/
                jigDataTable.Columns.Add("fld_stat", typeof(string));



                // Loop through the rows in the Excel worksheets for Eqp and Jig
                foreach (var row in eqpWorkbook.Worksheet(1).Rows().Skip(2))
                {
                    
                    // Customize how you read data from the Excel rows
                    var calibrationdate = row.Cell(1).Value.ToString();
                    var fld_actualCalibDueDate = row.Cell(2).Value.ToString();
                    var fld_codeNo = row.Cell(3).Value.ToString();
                    var fld_ctrlNo = row.Cell(4).Value.ToString();
                    var fld_eqpName = row.Cell(5).Value.ToString();
                    var fld_eqpModelNo = row.Cell(6).Value.ToString();
                    var fld_serial = row.Cell(7).Value.ToString();
                    var fld_brand = row.Cell(8).Value.ToString();
                    var fld_term = row.Cell(9).Value.ToString();
                    var fld_reqFunction = row.Cell(10).Value.ToString();
                    var fld_remarks = row.Cell(11).Value.ToString();
                    var fld_passFail = row.Cell(12).Value.ToString();
                    var fld_imte = row.Cell(13).Value.ToString();
                    var fld_calibDate = row.Cell(14).Value.ToString();
                    var fld_calibMonth = row.Cell(15).Value.ToString();
                    var fld_calibYear = row.Cell(16).Value.ToString();
                    var fld_nextCalibDate = row.Cell(17).Value.ToString();
                    var fld_nextCalibMonth = row.Cell(18).Value.ToString();
                    var fld_nextCalibYear = row.Cell(19).Value.ToString();
                    var fld_internalExternal = row.Cell(20).Value.ToString();
                    var fld_comment = row.Cell(21).Value.ToString();
                    var fld_supplierExternal = row.Cell(22).Value.ToString();
                    var fld_appStandardEqp = row.Cell(23).Value.ToString();
                    var fld_pathIMG = row.Cell(24).Value.ToString();
                    var fld_pathDoc = row.Cell(25).Value.ToString();
                    var fld_stat = row.Cell(26).Value.ToString();
                    var fld_dateReturned = row.Cell(27).Value.ToString();
                    var fld_withNC = row.Cell(28).Value.ToString();
                    var fld_CalibFR = row.Cell(29).Value.ToString();
                    var fld_calibDisSusForm = row.Cell(30).Value.ToString();
                    var fld_withCalibResult = row.Cell(31).Value.ToString();
                    var fld_incharge = row.Cell(32).Value.ToString();
                    var fld_changeSticker = row.Cell(33).Value.ToString();
                    var fld_dateRecv = row.Cell(34).Value.ToString();
                    var idd = "";
                    var fld_month = monthValue.ToString();
                    var fld_year = yearValue.ToString(); /*Data of this is from id = "yearUpload"*/



                    // Add data to the DataTable
                    eqpDataTable.Rows.Add( calibrationdate, fld_actualCalibDueDate, fld_codeNo, fld_ctrlNo, 
                          fld_eqpName, fld_eqpModelNo, fld_serial,
                        fld_brand, fld_term, fld_reqFunction, fld_remarks, fld_passFail, fld_imte, fld_calibDate, fld_calibMonth,
                        fld_calibYear, fld_nextCalibDate, fld_nextCalibMonth, fld_nextCalibYear, fld_internalExternal, fld_supplierExternal,
                        fld_comment, fld_appStandardEqp, fld_pathIMG, fld_pathDoc, fld_stat, fld_dateReturned, fld_withNC, fld_CalibFR,
                        fld_calibDisSusForm, fld_withCalibResult, fld_incharge, fld_changeSticker,
                         fld_dateRecv,idd, fld_month, fld_year );


                }

                foreach (var row in jigWorkbook.Worksheet(1).Rows().Skip(2))
                {
                    // Customize how to read data from the Excel rows for Eqp
                   
                    var calibrationdate = row.Cell(1).Value.ToString();
                    var fld_actualCalibDueDate = row.Cell(2).Value.ToString();
                    var fld_ctrlNo = row.Cell(3).Value.ToString();
                    var fld_jigName = row.Cell(4).Value.ToString();
                    var fld_drawingNo = row.Cell(5).Value.ToString();
                    var fld_term = row.Cell(6).Value.ToString();
                    var fld_reqFunction = row.Cell(7).Value.ToString();
                    var fld_remarks = row.Cell(8).Value.ToString();
                    var fld_passfail = row.Cell(9).Value.ToString();
                    var fld_imte = row.Cell(10).Value.ToString();
                    var fld_dateRecv = row.Cell(11).Value.ToString();
                    var fld_calibDate = row.Cell(12).Value.ToString();
                    var fld_calibMonth = row.Cell(13).Value.ToString();
                    var fld_calibYear = row.Cell(14).Value.ToString();
                    var fld_nextCalibDate = row.Cell(15).Value.ToString();
                    var fld_nextCalibMonth = row.Cell(16).Value.ToString();
                    var fld_nextCalibYear = row.Cell(17).Value.ToString();
                    var fld_dateReturned = row.Cell(18).Value.ToString();
                    var fld_internalExternal = row.Cell(19).Value.ToString();
                    var fld_withNC = row.Cell(20).Value.ToString();
                    var fld_CalibFR = row.Cell(21).Value.ToString();
                    var fld_calibDisSusForm = row.Cell(22).Value.ToString();
                    var fld_withCalibResult = row.Cell(23).Value.ToString();
                    var fld_pathDoc = row.Cell(24).Value.ToString();
                    var fld_pathIMG = row.Cell(25).Value.ToString();
                    var fld_incharge = row.Cell(26).Value.ToString();
                    var fld_changeSticker = row.Cell(27).Value.ToString();
                    var fld_codeNo = row.Cell(28).Value.ToString();
                    var idd = "";
                    var fld_month = monthValue.ToString(); /*Data of this is from id = "monthUpload"*/
                    var fld_year = yearValue.ToString(); /*Data of this is from id = "yearUpload"*/
                    var fld_stat = "";



                    // Add data to the DataTable for jig
                    jigDataTable.Rows.Add( calibrationdate, fld_actualCalibDueDate,  fld_ctrlNo,  fld_jigName,  fld_drawingNo, fld_term, fld_reqFunction, fld_remarks,
                        fld_passfail,  fld_imte, fld_dateRecv, fld_calibDate, fld_calibMonth, fld_calibYear, fld_nextCalibDate, fld_nextCalibMonth,
                        fld_nextCalibYear, fld_dateReturned, fld_internalExternal, fld_withNC, fld_CalibFR, fld_calibDisSusForm, fld_withCalibResult,
                        fld_pathDoc, fld_pathIMG, fld_incharge,  fld_changeSticker , fld_codeNo, idd, fld_month, fld_year, fld_stat);



                }
                string con = "Data Source=172.29.2.96;Initial Catalog=db_CalibrationSystem;User ID=sa;Password=qa1server*";
                // Perform SQLBulkCopy to insert data into the database for Eqp and Jig
                using (var connection = new SqlConnection(con))
                {
                    connection.Open();

                    using (var eqpBulkCopy = new SqlBulkCopy(connection))
                    using (var jigBulkCopy = new SqlBulkCopy(connection))
                    {
                        eqpBulkCopy.DestinationTableName = "CalibrationResultEQP";
                        eqpBulkCopy.WriteToServer(eqpDataTable);

                        jigBulkCopy.DestinationTableName = "CalibrationResultJIG";
                        jigBulkCopy.WriteToServer(jigDataTable);
                    }
                }


                // Update the value of fld_stat to "SCHEDULE UPLOAD OK"
                var calibrationNotice = _context.CalibrationNotice_table.FirstOrDefault(r => r.Id == editId);
                if (calibrationNotice != null)
                {
                    calibrationNotice.fld_stat = "SCHEDULE UPLOAD OK";
                    _context.SaveChanges();
                }
                else
                {
                    return Json(new {message = "update failed" });
                }


                // Handle success, e.g., return a success message
                return Json(new { success = true, message = "Upload successful" });
            }
            catch (Exception ex)
            {
                // Handle errors, e.g., log the exception and return an error message
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }



            
        }




        private List<SelectListItem> GetEmail()
        {
            List<SelectListItem> selDept = _context.EmailList_table
                .OrderBy(n => n.fld_emailAddress)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.fld_emailAddress.ToString(),
                    Text = n.fld_emailAddress
                }).ToList();

            var selItem = new SelectListItem()
            {
                Value = "",
                Text = "SELECT EMAIL BELOW"
            };

            selDept.Insert(0, selItem);
            return selDept;
        }


    }
}


