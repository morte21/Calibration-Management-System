// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;

namespace Calibration_Management_System.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                //// Email the user to reset their password
                //await _emailSender.SendEmailAsync(
                //    Input.Email,
                //    "Reset Password",
                //    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                // Email the user to reset their password
                string userEmailBody = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                SendEmailToUser(Input.Email, "Reset Password", userEmailBody);

                // Email the administrator
                string adminEmailBody = "Please be informed that " + Input.Email + " has requested a password reset.";
                SendEmailToAdministrator(adminEmailBody);

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }

        private void SendEmailToAdministrator(string emailBody)
        {
            string adminEmailAddress = "jason.casupanan@sanyodenki.com";
            string emailSubject = "Password Reset Request";

            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress("sdp.system@outlook.ph", "Calibration System");
            message.Priority = MailPriority.High;
            message.Body = emailBody;

            // To
            message.To.Add(new MailAddress(adminEmailAddress));

            // CC
            message.CC.Add(new MailAddress(adminEmailAddress));

            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);
        }

        private void SendEmailToUser(string toEmail, string subject, string emailBody)
        {
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress("sdp.system@outlook.ph", "Calibration System");
            message.Priority = MailPriority.High;
            message.Body = emailBody;

            // To
            message.To.Add(new MailAddress(toEmail));

            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = "smtp-mail.outlook.com";
            emailClient.UseDefaultCredentials = false;
            emailClient.EnableSsl = true;
            emailClient.Credentials = new NetworkCredential("sdp.system@outlook.ph", "qasysdev01*");
            emailClient.Port = 25;
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.Send(message);
        }
    }
}
