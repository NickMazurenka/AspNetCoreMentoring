using Microsoft.Extensions.DependencyInjection;
using NorthwindTraders.Application.UserNotification;

namespace NorthwindTraders.Adapters.Driven.EmailSender
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailSenderAdapter(this IServiceCollection services, string apiUser, string apiKey)
        {
            services.AddTransient<IEmailSender, EmailSender>(_ => new EmailSender(apiUser, apiKey));
            return services;
        }
    }
}
