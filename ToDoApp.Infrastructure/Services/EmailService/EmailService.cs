using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Services.EmailService;

namespace ToDoApp.Infrastructure.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(string from, string to, string message, string title)
        {
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = title;
            mailMessage.Body = message;

            SmtpClient client = new SmtpClient("smtp-relay.sendinblue.com");
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Port = 587;
            client.Credentials = new NetworkCredential("Leooalonso@gmail.com", "R4PUIhCZXEvAJ7k8");

            await client.SendMailAsync(mailMessage);
        }
    }
}
