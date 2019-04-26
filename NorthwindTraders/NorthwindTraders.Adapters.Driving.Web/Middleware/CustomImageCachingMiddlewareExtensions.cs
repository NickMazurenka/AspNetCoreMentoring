using Microsoft.AspNetCore.Builder;

namespace NorthwindTraders.Adapters.Driving.Web.Middleware
{
    public static class CustomImageCachingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomImageCaching(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomImageCachingMiddleware>();
        }
    }
}
