using System.Threading.Tasks;

namespace NorthwindTraders.Application.UserNotification
{
    public interface ISendEmailService
    {
        Task SendEmailAsync(string targetEmailAddress, string subject, string message);
    }
}
