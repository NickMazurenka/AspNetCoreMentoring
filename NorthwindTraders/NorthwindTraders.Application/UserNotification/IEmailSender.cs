using System.Threading.Tasks;

namespace NorthwindTraders.Application.UserNotification
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string targetEmailAddress, string subject, string message);
    }
}
