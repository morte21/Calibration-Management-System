using Calibration_Management_System.Data;
using Calibration_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;




namespace Calibration_Management_System.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private UserManager<IdentityUser> _userManager;

       

        public RegistrationController(ApplicationDbContext context, IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
        }

        //VIEW EQUPMENT REGISTRATION PAGE
        public IActionResult Index()
        {
            List<RegistrationClass> registrationClass;
            //registrationClass = _context.Registration_Table.ToList();

            registrationClass = _context.Registration_Table.Where(x => x.fld_jigCategory == "EQP").ToList();
            //sort decs by id
            //registrationClass = _context.Registration_Table.OrderByDescending(x => x.id).ToList();
            return View(registrationClass);
        }

        //VIEW JIG REGISTRATION PAGE
        public IActionResult IndexJig()
        {
            List<RegistrationClass> registrationClassJig;
            registrationClassJig = _context.Registration_Table.Where(x => x.fld_jigCategory == "JIG").ToList();
            return View(registrationClassJig);
        }


        // JIG
        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpGet]
        public IActionResult Create_Reg_Jig()
        {
            RegistrationClass registrationClass = new RegistrationClass();

            ViewBag.Status = GetStatus();
            ViewBag.RequestingFunction = GetRequestingFunctions();
            return View(registrationClass);
        }


        //VIEW EQP
        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpGet]

        //VIEW EQP
        public IActionResult Create_Reg()
        {
            RegistrationClass registrationClass = new RegistrationClass();

            ViewBag.Status = GetStatus();
            ViewBag.RequestingFunction = GetRequestingFunctions();
            return View(registrationClass);
        }

        //VIEW JIG
        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpPost]
        public IActionResult Create_Reg_Jig(RegistrationClass RegistrationClass)
        {
            


            _context.Registration_Table.Add(RegistrationClass);
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
                    <h1 style=""margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 30px; font-weight: normal; letter-spacing: normal; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;"">New Jig Registration Request</h1>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5;"">

                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">{reqfunction} is requesting a new jig registration for {jigName}.</p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 18px;""> </p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">Details for the new registration<br/>Model: {drawingNo}<br/>Jig Name: {jigName}<br/>Maker/Brand: {makerBrand}<br/>Person-In-Charge: {personInCharge}</p>
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
            string drawingNo = RegistrationClass.fld_drawingNo;
            string jigName = RegistrationClass.fld_jigName;
            string makerBrand = RegistrationClass.fld_brand;
            string personInCharge = RegistrationClass.fld_incharge;
            string reqfunction = RegistrationClass.fld_reqFunction;

            //228
            HTML = HTML.Replace("{jigName}", jigName)
                       .Replace("{drawingNo}", drawingNo)
                       .Replace("{makerBrand}", makerBrand)
                       .Replace("{personInCharge}", personInCharge)
                        .Replace("{reqfunction}", reqfunction);


            MailMessage message = new MailMessage();
            message.Subject = "Calibration System - Request Notification";
            message.IsBodyHtml = true;
            message.From = (new MailAddress("sdp.system@outlook.ph", "Calibration System"));
            message.Priority = MailPriority.High;
            message.Body = HTML;


            //get user email
            string userName = _userManager.GetUserName(User);
            
            //To
            message.To.Add(new MailAddress(userName));
            

            //CC
            message.CC.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));
            message.CC.Add(new MailAddress("edmon.isip@sanyodenki.com"));
            message.CC.Add(new MailAddress("sdp-qacalibration@sanyodenki.com"));
            message.CC.Add(new MailAddress("ronald.ramos@sanyodenki.com"));



            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);






            return RedirectToAction("IndexJig");
        }

        //VIEW EQP
        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpPost]
        public IActionResult Create_Reg(RegistrationClass RegistrationClass)
        {

            _context.Registration_Table.Add(RegistrationClass);
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
                    <h1 style=""margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 30px; font-weight: normal; letter-spacing: normal; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;"">New Equipment Registration Request</h1>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5;"">

                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">{reqfunction} is requesting a new equipment registration for {equipmentName}.</p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 18px;""> </p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">Details for the new registration<br/>Model: {model}<br/>Equipment Name: {equipmentName}<br/>Maker/Brand: {makerBrand}<br/>Person-In-Charge: {personInCharge}</p>
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
            string model = RegistrationClass.fld_eqpModelNo;
            string equipmentName = RegistrationClass.fld_eqpName;
            string makerBrand = RegistrationClass.fld_brand;
            string personInCharge = RegistrationClass.fld_incharge;
            string reqfunction = RegistrationClass.fld_reqFunction;

            HTML = HTML.Replace("{equipmentName}", equipmentName)
                       .Replace("{model}", model)
                       .Replace("{makerBrand}", makerBrand)
                       .Replace("{personInCharge}", personInCharge)
                        .Replace("{reqfunction}", reqfunction);


            MailMessage message = new MailMessage();
            message.Subject = "Calibration System - Request Notification";
            message.IsBodyHtml = true;
            message.From = (new MailAddress("sdp.system@outlook.ph", "Calibration System"));
            message.Priority = MailPriority.High;
            message.Body = HTML;

            //get user email
            string userName = _userManager.GetUserName(User);

            //To
            message.To.Add(new MailAddress(userName));


            //CC
            message.CC.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));
            message.CC.Add(new MailAddress("edmon.isip@sanyodenki.com"));
            message.CC.Add(new MailAddress("sdp-qacalibration@sanyodenki.com"));
            message.CC.Add(new MailAddress("ronald.ramos@sanyodenki.com"));


            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);






            return RedirectToAction("Index");
        }

        //VIEW JIG
        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpGet]
        public IActionResult Create_ReReg_Jig()
        {
            RegistrationClass registrationClass = new RegistrationClass();

            ViewBag.Status = GetStatus();
            ViewBag.RequestingFunction = GetRequestingFunctions();
            return View(registrationClass);
        }

        //VIEW EQP
        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpGet]
        public IActionResult Create_ReReg()
        {
            RegistrationClass registrationClass = new RegistrationClass();

            ViewBag.Status = GetStatus();
            ViewBag.RequestingFunction = GetRequestingFunctions();
            return View(registrationClass);
        }


        //VIEW EQP
        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpPost]
        public IActionResult Create_ReReg_Jig(RegistrationClass RegistrationClass)
        {

            _context.Registration_Table.Add(RegistrationClass);
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
                    <h1 style=""margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 30px; font-weight: normal; letter-spacing: normal; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;"">Jig Re-Registration Request</h1>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5;"">

                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">{reqfunction} is requesting a equipment re-registration for {jigName}.</p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 18px;""> </p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">Details for the new registration<br/>Model: {drawingNo}<br/>Equipment Name: {jigName}<br/>Maker/Brand: {makerBrand}<br/>Person-In-Charge: {personInCharge}</p>
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
            string drawingNo = RegistrationClass.fld_drawingNo;
            string jigName = RegistrationClass.fld_jigName;
            string makerBrand = RegistrationClass.fld_brand;
            string personInCharge = RegistrationClass.fld_incharge;
            string reqfunction = RegistrationClass.fld_reqFunction;

            //228
            HTML = HTML.Replace("{jigName}", jigName)
                       .Replace("{drawingNo}", drawingNo)
                       .Replace("{makerBrand}", makerBrand)
                       .Replace("{personInCharge}", personInCharge)
                        .Replace("{reqfunction}", reqfunction);


            MailMessage message = new MailMessage();
            message.Subject = "Calibration System - Request Notification";
            message.IsBodyHtml = true;
            message.From = (new MailAddress("sdp.system@outlook.ph", "Calibration System"));
            message.Priority = MailPriority.High;
            message.Body = HTML;

            //get user email
            string userName = _userManager.GetUserName(User);

            //To
            message.To.Add(new MailAddress(userName));


            //CC
            message.CC.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));
            message.CC.Add(new MailAddress("edmon.isip@sanyodenki.com"));
            message.CC.Add(new MailAddress("sdp-qacalibration@sanyodenki.com"));
            message.CC.Add(new MailAddress("ronald.ramos@sanyodenki.com"));


            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);






            return RedirectToAction("IndexJig");
        }



        //VIEW EQP
        [Authorize(Roles = "Control Function,Admin-Calibration,Using Function")]
        [HttpPost]
        public IActionResult Create_ReReg(RegistrationClass RegistrationClass)
        {

            _context.Registration_Table.Add(RegistrationClass);
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
                    <h1 style=""margin: 0; color: #000000; direction: ltr; font-family: 'Playfair Display', Georgia, serif; font-size: 30px; font-weight: normal; letter-spacing: normal; line-height: 120%; text-align: left; margin-top: 0; margin-bottom: 0;"">Equipment Re-Registration Request</h1>
                    </td>
                    </tr>
                    </table>
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""text_block block-4"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"" width=""100%"">
                    <tr>
                    <td class=""pad"" style=""padding-bottom:20px;padding-top:20px;"">
                    <div style=""font-family: sans-serif"">
                    <div class="""" style=""font-size: 12px; font-family: Montserrat, Trebuchet MS, Lucida Grande, Lucida Sans Unicode, Lucida Sans, Tahoma, sans-serif; mso-line-height-alt: 18px; color: #1d1d1b; line-height: 1.5;"">

                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">{reqfunction} is requesting a equipment re-registration for {equipmentName}.</p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 18px;""> </p>
                    <p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 21px;"">Details for the new registration<br/>Model: {model}<br/>Equipment Name: {equipmentName}<br/>Maker/Brand: {makerBrand}<br/>Person-In-Charge: {personInCharge}</p>
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
            string model = RegistrationClass.fld_eqpModelNo;
            string equipmentName = RegistrationClass.fld_eqpName;
            string makerBrand = RegistrationClass.fld_brand;
            string personInCharge = RegistrationClass.fld_incharge;
            string reqfunction = RegistrationClass.fld_reqFunction;

            HTML = HTML.Replace("{equipmentName}", equipmentName)
                       .Replace("{model}", model)
                       .Replace("{makerBrand}", makerBrand)
                       .Replace("{personInCharge}", personInCharge)
                        .Replace("{reqfunction}", reqfunction);


            MailMessage message = new MailMessage();
            message.Subject = "Calibration System - Request Notification";
            message.IsBodyHtml = true;
            message.From = (new MailAddress("sdp.system@outlook.ph", "Calibration System"));
            message.Priority = MailPriority.High;
            message.Body = HTML;

            //get user email
            string userName = _userManager.GetUserName(User);

            //To
            message.To.Add(new MailAddress(userName));


            //CC
            message.CC.Add(new MailAddress("sdp-qa1systemdevt@sanyodenki.com"));
            message.CC.Add(new MailAddress("edmon.isip@sanyodenki.com"));
            message.CC.Add(new MailAddress("sdp-qacalibration@sanyodenki.com"));
            message.CC.Add(new MailAddress("ronald.ramos@sanyodenki.com"));


            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);

            return RedirectToAction("Index");
        }


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


        [HttpGet]
        public IActionResult EditGet(int id)
        {
            // Retrieve the data from your database using the 'id' parameter
            var equipmentRegistration = _context.Equipment_table.FirstOrDefault(a => a.id == id);

            if (equipmentRegistration == null)
            {
                // Handle the case when the data is not found
                return NotFound();
            }

            // Construct the URL with query parameters
            var url = $"/EquipmentMaster/EditGet?codeNo={equipmentRegistration.fld_codeNo}&eqpName={equipmentRegistration.fld_eqpName}&eqpModelNo={equipmentRegistration.fld_eqpModelNo}&serial={equipmentRegistration.fld_serial}&brand={equipmentRegistration.fld_brand}&reqFunction={equipmentRegistration.fld_reqFunction}&ctrlNo={equipmentRegistration.fld_ctrlNo}&id={equipmentRegistration.id}";

            // Redirect to the URL
            return Redirect(url);
        }




        [HttpPost]
        public IActionResult Edit_DataJig(RegistrationClass registrationClass)
        {
            _context.Attach(registrationClass);
            _context.Entry(registrationClass).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("IndexJig");
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Edit_DataJig(int Id)
        {

            RegistrationClass registration = _context.Registration_Table.FirstOrDefault(r => r.id == Id);

            ViewBag.RequestingFunction = GetRequestingFunctions();

            ViewBag.Status = GetStatus();
            return View("Edit_DataJig", registration);
        }

        [Authorize(Roles = "Control Function,Admin-Calibration")]
        [HttpGet]
        public IActionResult Edit_Data(int Id)
        {

            RegistrationClass registration = _context.Registration_Table.FirstOrDefault(r => r.id == Id);

            ViewBag.RequestingFunction = GetRequestingFunctions();

            ViewBag.Status = GetStatus();
            return View("Edit_Data", registration);
        }

        [HttpPost]
        public IActionResult Edit_Data(RegistrationClass registrationClass)
        {
            _context.Attach(registrationClass);
            _context.Entry(registrationClass).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        private List<SelectListItem> GetStatus()
        {
            List<SelectListItem> selStatus = new List<SelectListItem>();
            var selItem = new SelectListItem() { Value = "", Text = "Select" };
            selStatus.Insert(0, selItem);
            selItem = new SelectListItem()
            {
                Value = "PENDING",
                Text = "PENDING"
            };
            selStatus.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "ONGOING",
                Text = "ONGOING"
            };
            selStatus.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "COMPLETED",
                Text = "COMPLETED"
            };
            selStatus.Add(selItem);

            return selStatus;
        }





    }
}
