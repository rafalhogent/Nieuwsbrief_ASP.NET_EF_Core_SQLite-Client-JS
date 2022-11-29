using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public class EmailingService : IEmailingService
    {
        private readonly EmailingServiceConfig _emailingConfig;

        public EmailingService(IOptionsMonitor<EmailingServiceConfig> optionsMonitor)
        {
            _emailingConfig = optionsMonitor.CurrentValue;
        }

        public async Task SendEmailAsync(string email)
        {

            string email_from = _emailingConfig.EMAIL_FROM;
            string smtp_username = _emailingConfig.SMTP_USERNAME;
            string smtp_password = _emailingConfig.SMTP_PASSWORD;
            string smtp_server = _emailingConfig.SMTP_SERVER;
            int smtp_port = _emailingConfig.SMTP_PORT;

            MailAddress to = new MailAddress(email);
            MailAddress from = new MailAddress(email_from);
            MailMessage message = new MailMessage(from, to);


            message.Subject = "Welkom in Nieuwsbrief";
            message.Body = "Je bent ingeschreven op onze wekelijkse nieuwsbrief";
            SmtpClient client = new SmtpClient(smtp_server, smtp_port)
            {
                Credentials = new NetworkCredential(smtp_username, smtp_password),
                EnableSsl = true
            };

            try
            {
               await client.SendMailAsync(message);
            }
            catch (SmtpException )
            {

            }
        }
    }
}
