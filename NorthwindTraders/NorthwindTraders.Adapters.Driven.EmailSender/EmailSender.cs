using System.Threading.Tasks;
using NorthwindTraders.Application.UserNotification;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NorthwindTraders.Adapters.Driven.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly string _apiKey;

        public EmailSender(string apiUser, string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task SendEmailAsync(string targetEmailAddress, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress("noreply@northwindtraders.com", "Northwind Traders"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(targetEmailAddress));

            msg.SetClickTracking(false, false);

            await client.SendEmailAsync(msg);
        }
    }
}
