using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Core.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmail(string from, string to, string message, string title);
    }
}
