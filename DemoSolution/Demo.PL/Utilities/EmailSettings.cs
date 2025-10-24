using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Demo.PL.Utilities
{
    public static class EmailSettings
    {
        public static async Task<bool> SendEmailAsync(Email email)
        {
            // NOTE: Move credentials to configuration or user secrets in real apps.
            string SmtpServer = "smtp.gmail.com";
            int SmtpPort =587;
            string SmtpUser = "";
            string SmtpPass = "";
            try
            {
                using var client = new SmtpClient(SmtpServer, SmtpPort)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(SmtpUser, SmtpPass),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage(SmtpUser, email.To, email.Subject, email.Body);
                await client.SendMailAsync(mailMessage);
                return true;
            }  
            catch
            {
                return false;
            }
        }
    }
}
