using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace Shope.PL.helper
{
    public class SendingEmail : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("basheirdaoud@gmail.com", "ukzm cete khcx euqm")
            };

            return client.SendMailAsync(
                new MailMessage(from: "basheirdaoud@gmail.com",
                                to: email,
                                subject,
                                htmlMessage
                                )
                { IsBodyHtml=true});
        }
    }
}
