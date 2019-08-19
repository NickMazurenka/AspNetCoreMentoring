using System.Threading.Tasks;

namespace NorthwindTraders.Application.UserNotification
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IEmailSender _emailSender;

        public SendEmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task SendEmailAsync(string targetEmailAddress, string subject, string message)
        {
            await _emailSender.SendEmailAsync(targetEmailAddress, subject, message);
        }
    }
}
