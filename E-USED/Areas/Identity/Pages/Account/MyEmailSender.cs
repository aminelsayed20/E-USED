using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace E_USED.Areas.Identity.Pages.Account
{
    public class MyEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public MyEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

 

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var fromAddress = new MailAddress("aminelsayed020202@gmail.com", "E-Used Team");
                var toAddress = new MailAddress(email);
                var fromPassword = _configuration["EmailSettings:Password"];

                using (var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                })
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true
                })
                {
                    await smtpClient.SendMailAsync(message);
                    Console.WriteLine("**********Message sent successfully!***********");
                }
            }
            catch (Exception ex)
            {
                // Log the exception message to understand the failure
                Console.WriteLine($"*******************Error sending email: {ex.Message}");
                // Optionally, rethrow or handle the exception appropriately
            }
        }
    }
}
