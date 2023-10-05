﻿using Calibration_Management_System.Data;
using Calibration_Management_System.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace Calibration_Management_System.Controllers
{
    public class SuspendDisposeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public SuspendDisposeController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        [HttpGet]
        public IActionResult DetailsSuspend(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            SuspendDisposeRegistration init = _context.SuspendDispose_table
                .Where(a => a.id == Id)
                .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            ViewBag.RequestingFunction = GetRequestingFunctions();

            return View(init);
        }

        //SUSPENDED
        public IActionResult IndexSuspend()
        {
            List<SuspendDisposeRegistration> SusDisRegistration;
            SusDisRegistration = _context.SuspendDispose_table.Where(x => x.fld_reqStatus == "SUSPEND").ToList();
            return View(SusDisRegistration);
        }

        public IActionResult IndexSuspend2()
        {
            List<SuspendDisposeRegistration> SusDisRegistration;
            SusDisRegistration = _context.SuspendDispose_table.Where(x => x.fld_reqStatus == "SUSPEND").ToList();

            return View(SusDisRegistration);
        }

        // suspend
        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpGet]
        public IActionResult Create_Suspend()
        {
            SuspendDisposeRegistration SusDisRegistration = new SuspendDisposeRegistration();
            ViewBag.RequestingFunction = GetRequestingFunctions();
            return View(SusDisRegistration);
        }

        [HttpPost]
        public IActionResult Create_Suspend(SuspendDisposeRegistration SusDisRegistration)
        {
            _context.SuspendDispose_table.Add(SusDisRegistration);
            _context.SaveChanges();


            string HTML = @"<html>
                    <head>
                    <title></title>
                    <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type""/>
                    <meta content=""width=device-width, initial-scale=1.0"" name=""viewport""/><!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]--><!--[if !mso]><!-->
                    <link href=""https://fonts.googleapis.com/css?family=Montserrat"" rel=""stylesheet"" type=""text/css""/>
                    <link href=""https://fonts.googleapis.com/css?family=Playfair+Display"" rel=""stylesheet"" type=""text/css""/><!--<![endif]-->
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
			                    mso-hide: all;
			                    display: none;
			                    max-height: 0px;
			                    overflow: hidden;
		                    }

		                    .image_block img+div {
			                    display: none;
		                    }

		                    @media (max-width:700px) {

			                    .desktop_hide table.icons-inner,
			                    .social_block.desktop_hide .social-table {
				                    display: inline-block !important;
			                    }

			                    .icons-inner {
				                    text-align: center;
			                    }

			                    .icons-inner td {
				                    margin: 0 auto;
			                    }

			                    .row-content {
				                    width: 100% !important;
			                    }

			                    .mobile_hide {
				                    display: none;
			                    }

			                    .stack .column {
				                    width: 100%;
				                    display: block;
			                    }

			                    .mobile_hide {
				                    min-height: 0;
				                    max-height: 0;
				                    max-width: 0;
				                    overflow: hidden;
				                    font-size: 0px;
			                    }

			                    .desktop_hide,
			                    .desktop_hide table {
				                    display: table !important;
				                    max-height: none !important;
			                    }
		                    }
	                    </style>
                    </head>
                    <body style=""background-color: #e3e3e3; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nl-container"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #e3e3e3;"" width=""100%"">
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
                    <h2 style=""margin: 0; color: #000000; direction: ltr; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; font-size: 16px; font-weight: normal; letter-spacing: 1px; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;""><span class=""tinyMce-placeholder"">Calibration System</span></h2>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""heading_block block-3"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:10px;text-align:center;width:100%;"">
                    <h1 style=""margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 30px; font-weight: normal; letter-spacing: normal; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;"">Suspend Notification</h1>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5;"">

                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">{requestFuntion} is requesting to suspend the {itemName}.</p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 18px;""> </p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">Details of the suspended item<br/>Item Name: {itemName}<br/>Reason: {reason}<br/>Incharge/Requestor: {inchargeReq}<br/>Fixed Asset: {fixedAsset}</p>
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
                    <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">For your information and guidance.</span><br/><span style=""font-size:9px;"">Any concerns and clarification kindly inform the undersigned.</span><br/><span style=""font-size:9px;""><a href=""mailto:sdp-qacalibration@sanyodenki.com"" style=""text-decoration: underline; color: #e5af88;"">sdp-qacalibration@sanyodenki.com</a></span></p>
                    <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">Local number: 109</span></p>
                    <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">SANYO DENKI Philippines Inc.</span><br/><span style=""font-size:9px;"">Calibration System Automatic Email Notification</span></p>
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
                    <p style=""margin: 0; font-size: 10px; text-align: center; mso-line-height-alt: 15px;""><span style=""font-size:10px;""><span style=""""><span style=""color:#999999;""> <br/></span></span><span style=""color:#999999;"">© 2023 Sanyo Denki Philippines. All Rights Reserved.</span></span></p>
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

            // Replace placeholders with actual values
            string itemName = SusDisRegistration.fld_itemName;
            string requestFuntion = SusDisRegistration.fld_reqFunction;
            string inchargeReq = SusDisRegistration.fld_inchargeRequestor;
            string fixedAsset = SusDisRegistration.fld_fixedAsset;
            string reason = SusDisRegistration.fld_reason;

            //228
            HTML = HTML.Replace("{itemName}", itemName)
                       .Replace("{reason}", reason)
                       .Replace("{inchargeReq}", inchargeReq)
                       .Replace("{fixedAsset}", fixedAsset)
                        .Replace("{requestFuntion}", requestFuntion);


            MailMessage message = new MailMessage();
            message.Subject = "Calibration System - Request Notification";
            message.IsBodyHtml = true;
            message.From = (new MailAddress("sdp.system@outlook.ph", "Calibration System"));
            message.Priority = MailPriority.High;
            message.Body = HTML;

            //To
            message.To.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));

            //CC
            message.CC.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));


            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);


            return RedirectToAction("IndexSuspend");
        }


        [HttpGet]
        public IActionResult Edit_Suspend(int Id)
        {
            SuspendDisposeRegistration SusDisRegistration = _context.SuspendDispose_table.FirstOrDefault(r => r.id == Id);
            return View("Edit_Suspend", SusDisRegistration);
        }


        [HttpPost]
        public IActionResult Edit_Suspend(SuspendDisposeRegistration SusDisRegistration)
        {
            _context.Attach(SusDisRegistration);
            _context.Entry(SusDisRegistration).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("IndexSuspend");
        }

        [HttpGet]
        public IActionResult Edit_Suspend2(int Id)
        {
            SuspendDisposeRegistration SusDisRegistration = _context.SuspendDispose_table.FirstOrDefault(r => r.id == Id);
            return View("Edit_Suspend2", SusDisRegistration);
        }


        [HttpPost]
        public IActionResult Edit_Suspend2(SuspendDisposeRegistration SusDisRegistration)
        {
            _context.Attach(SusDisRegistration);
            _context.Entry(SusDisRegistration).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("IndexSuspend2");
        }


        [HttpGet]
        public IActionResult ActivateSuspend(int Id)
        {
            SuspendDisposeRegistration SusDisRegistration = _context.SuspendDispose_table.FirstOrDefault(r => r.id == Id);
            return View("ActivateSuspend", SusDisRegistration);
        }


        [HttpPost]
        public IActionResult ActivateSuspendConfirmed(int Id) // Assuming you're passing an ID to identify the specific row
        {
            // Retrieve the specific SuspendDisposeRegistration record using the provided ID
            SuspendDisposeRegistration SusDisRegistration = _context.SuspendDispose_table.FirstOrDefault(r => r.id == Id);

            if (SusDisRegistration != null)
            {
                if (SusDisRegistration.fld_calibType == "EQUIPMENT")
                {
                    // Search for corresponding EquipmentMaster data based on fld_ctrlsus
                    EquipmentRegistration equipment = _context.Equipment_table.FirstOrDefault(e => e.fld_ctrlNo == SusDisRegistration.fld_ctrlNo);

                    if (equipment != null)
                    {
                        // Update the desired column (fld_stat) in EquipmentMaster
                        equipment.fld_stat = "SUSPENDED"; // Set the new value you want to update
                    }
                    else
                    {
                       
                        
                    }
                }
                else if (SusDisRegistration.fld_calibType == "JIG")
                {
                    // Search for corresponding JigRegistration data based on fld_ctrlsus
                    JigRegistration jig = _context.Jig_table.FirstOrDefault(j => j.fld_ctrlNo == SusDisRegistration.fld_ctrlNo);

                    if (jig != null)
                    {
                        // Update the desired column (fld_stat) in JigRegistration
                        jig.fld_stat = "SUSPENDED"; // Set the new value you want to update
                    }
                    else
                    {
                        ViewBag.NotificationMessage = "Jig not found.";
                    }
                }

                // Save changes to the database
                _context.SaveChanges();
            }
            else
            {
                ViewBag.NotificationMessage = "Selected record not found.";
            }

            return RedirectToAction("IndexSuspend", "SuspendDispose"); // Redirect back to the SuspendDisposeController's IndexSuspend action
        }


        //DISPOSE

        [HttpGet]
        public IActionResult DetailsDisposed(int Id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            SuspendDisposeRegistration init = _context.SuspendDispose_table
                .Where(a => a.id == Id)
                .FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            ViewBag.RequestingFunction = GetRequestingFunctions();

            return View(init);
        }

        public IActionResult IndexDisposed()
        {
            List<SuspendDisposeRegistration> SusDisRegistration;
            SusDisRegistration = _context.SuspendDispose_table.Where(x => x.fld_reqStatus == "DISPOSED").ToList();
            return View(SusDisRegistration);
        }

        public IActionResult IndexDisposed2()
        {
            List<SuspendDisposeRegistration> SusDisRegistration;
            SusDisRegistration = _context.SuspendDispose_table.Where(x => x.fld_reqStatus == "DISPOSED").ToList();

            return View(SusDisRegistration);
        }

        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpGet]
        public IActionResult Create_Disposed()
        {
            SuspendDisposeRegistration SusDisRegistration = new SuspendDisposeRegistration();
            ViewBag.RequestingFunction = GetRequestingFunctions();
            return View(SusDisRegistration);
        }

        [HttpPost]
        public IActionResult Create_Disposed(SuspendDisposeRegistration SusDisRegistration)
        {
            _context.SuspendDispose_table.Add(SusDisRegistration);
            _context.SaveChanges();


            string HTML = @"<html>
                    <head>
                    <title></title>
                    <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type""/>
                    <meta content=""width=device-width, initial-scale=1.0"" name=""viewport""/><!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]--><!--[if !mso]><!-->
                    <link href=""https://fonts.googleapis.com/css?family=Montserrat"" rel=""stylesheet"" type=""text/css""/>
                    <link href=""https://fonts.googleapis.com/css?family=Playfair+Display"" rel=""stylesheet"" type=""text/css""/><!--<![endif]-->
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
			                    mso-hide: all;
			                    display: none;
			                    max-height: 0px;
			                    overflow: hidden;
		                    }

		                    .image_block img+div {
			                    display: none;
		                    }

		                    @media (max-width:700px) {

			                    .desktop_hide table.icons-inner,
			                    .social_block.desktop_hide .social-table {
				                    display: inline-block !important;
			                    }

			                    .icons-inner {
				                    text-align: center;
			                    }

			                    .icons-inner td {
				                    margin: 0 auto;
			                    }

			                    .row-content {
				                    width: 100% !important;
			                    }

			                    .mobile_hide {
				                    display: none;
			                    }

			                    .stack .column {
				                    width: 100%;
				                    display: block;
			                    }

			                    .mobile_hide {
				                    min-height: 0;
				                    max-height: 0;
				                    max-width: 0;
				                    overflow: hidden;
				                    font-size: 0px;
			                    }

			                    .desktop_hide,
			                    .desktop_hide table {
				                    display: table !important;
				                    max-height: none !important;
			                    }
		                    }
	                    </style>
                    </head>
                    <body style=""background-color: #e3e3e3; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nl-container"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #e3e3e3;"" width=""100%"">
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
                    <h2 style=""margin: 0; color: #000000; direction: ltr; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; font-size: 16px; font-weight: normal; letter-spacing: 1px; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;""><span class=""tinyMce-placeholder"">Calibration System</span></h2>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""heading_block block-3"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:10px;text-align:center;width:100%;"">
                    <h1 style=""margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 30px; font-weight: normal; letter-spacing: normal; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;"">Disposed Notification</h1>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5;"">

                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">{requestFuntion} is requesting to disposed the {itemName}.</p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 18px;""> </p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">Details of the disposed item<br/>Item Name: {itemName}<br/>Reason: {reason}<br/>Incharge/Requestor: {inchargeReq}<br/>Fixed Asset: {fixedAsset}</p>
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
                    <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">For your information and guidance.</span><br/><span style=""font-size:9px;"">Any concerns and clarification kindly inform the undersigned.</span><br/><span style=""font-size:9px;""><a href=""mailto:sdp-qacalibration@sanyodenki.com"" style=""text-decoration: underline; color: #e5af88;"">sdp-qacalibration@sanyodenki.com</a></span></p>
                    <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">Local number: 109</span></p>
                    <p style=""margin: 0; font-size: 9px; mso-line-height-alt: 13.5px;""><span style=""font-size:9px;"">SANYO DENKI Philippines Inc.</span><br/><span style=""font-size:9px;"">Calibration System Automatic Email Notification</span></p>
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
                    <p style=""margin: 0; font-size: 10px; text-align: center; mso-line-height-alt: 15px;""><span style=""font-size:10px;""><span style=""""><span style=""color:#999999;""> <br/></span></span><span style=""color:#999999;"">© 2023 Sanyo Denki Philippines. All Rights Reserved.</span></span></p>
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

            // Replace placeholders with actual values
            string itemName = SusDisRegistration.fld_itemName;
            string requestFuntion = SusDisRegistration.fld_reqFunction;
            string inchargeReq = SusDisRegistration.fld_inchargeRequestor;
            string fixedAsset = SusDisRegistration.fld_fixedAsset;
            string reason = SusDisRegistration.fld_reason;

            //228
            HTML = HTML.Replace("{itemName}", itemName)
                       .Replace("{reason}", reason)
                       .Replace("{inchargeReq}", inchargeReq)
                       .Replace("{fixedAsset}", fixedAsset)
                        .Replace("{requestFuntion}", requestFuntion);


            MailMessage message = new MailMessage();
            message.Subject = "Calibration System - Request Notification";
            message.IsBodyHtml = true;
            message.From = (new MailAddress("sdp.system@outlook.ph", "Calibration System"));
            message.Priority = MailPriority.High;
            message.Body = HTML;

            //To
            message.To.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));

            //CC
            message.CC.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));


            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);


            return RedirectToAction("IndexDisposed");
        }




        [HttpGet]
        public IActionResult Edit_Disposed(int Id)
        {
            SuspendDisposeRegistration SusDisRegistration = _context.SuspendDispose_table.FirstOrDefault(r => r.id == Id);
            return View("Edit_Disposed", SusDisRegistration);
        }


        [HttpPost]
        public IActionResult Edit_Disposed(SuspendDisposeRegistration SusDisRegistration)
        {
            _context.Attach(SusDisRegistration);
            _context.Entry(SusDisRegistration).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("IndexDisposed");
        }

        [HttpGet]
        public IActionResult Edit_Disposed2(int Id)
        {
            SuspendDisposeRegistration SusDisRegistration = _context.SuspendDispose_table.FirstOrDefault(r => r.id == Id);
            return View("Edit_Disposed2", SusDisRegistration);
        }


        [HttpPost]
        public IActionResult Edit_Disposed2(SuspendDisposeRegistration SusDisRegistration)
        {
            _context.Attach(SusDisRegistration);
            _context.Entry(SusDisRegistration).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("IndexDisposed2");
        }


        [HttpGet]
        public IActionResult ActivateDisposed(int Id)
        {
            SuspendDisposeRegistration SusDisRegistration = _context.SuspendDispose_table.FirstOrDefault(r => r.id == Id);
            return View("ActivateDisposed", SusDisRegistration);
        }


        [HttpPost]
        public IActionResult ActivateDisposedConfirmed(int Id) // Assuming you're passing an ID to identify the specific row
        {
            // Retrieve the specific SuspendDisposeRegistration record using the provided ID
            SuspendDisposeRegistration SusDisRegistration = _context.SuspendDispose_table.FirstOrDefault(r => r.id == Id);

            if (SusDisRegistration != null)
            {
                if (SusDisRegistration.fld_calibType == "EQUIPMENT")
                {
                    // Search for corresponding EquipmentMaster data based on fld_ctrlsus
                    EquipmentRegistration equipment = _context.Equipment_table.FirstOrDefault(e => e.fld_ctrlNo == SusDisRegistration.fld_ctrlNo);

                    if (equipment != null)
                    {
                        // Update the desired column (fld_stat) in EquipmentMaster
                        equipment.fld_stat = "DISPOSED"; // Set the new value you want to update
                    }
                    else
                    {


                    }
                }
                else if (SusDisRegistration.fld_calibType == "JIG")
                {
                    // Search for corresponding JigRegistration data based on fld_ctrlsus
                    JigRegistration jig = _context.Jig_table.FirstOrDefault(j => j.fld_ctrlNo == SusDisRegistration.fld_ctrlNo);

                    if (jig != null)
                    {
                        // Update the desired column (fld_stat) in JigRegistration
                        jig.fld_stat = "DISPOSED"; // Set the new value you want to update
                    }
                    else
                    {
                        ViewBag.NotificationMessage = "Jig not found.";
                    }
                }

                // Save changes to the database
                _context.SaveChanges();
            }
            else
            {
                ViewBag.NotificationMessage = "Selected record not found.";
            }

            return RedirectToAction("IndexDisposed", "SuspendDispose"); // Redirect back to the SuspendDisposeController's IndexSuspend action
        }













        //get data from db - list of departments
        private List<SelectListItem> GetRequestingFunctions()
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
                Value = null,
                Text = "Select Department"
            };

            selDept.Insert(0, selItem);
            return selDept;
        }


    }
}