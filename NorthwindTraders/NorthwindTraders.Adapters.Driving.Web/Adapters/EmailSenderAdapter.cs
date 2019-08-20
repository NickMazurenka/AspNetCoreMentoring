using System.Threading.Tasks;
using NorthwindTraders.Application.UserNotification;
using IEmailSender = Microsoft.AspNetCore.Identity.UI.Services.IEmailSender;

namespace NorthwindTraders.Adapters.Driving.Web.Adapters
{
    public class EmailSenderAdapter : IEmailSender
    {
        private readonly ISendEmailService _sendEmailService;

        public EmailSenderAdapter(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await _sendEmailService.SendEmailAsync(email, subject, htmlMessage);
        }
    }
}
