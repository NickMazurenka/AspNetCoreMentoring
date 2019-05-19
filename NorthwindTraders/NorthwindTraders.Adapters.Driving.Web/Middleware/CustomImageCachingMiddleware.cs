using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace NorthwindTraders.Adapters.Driving.Web.Middleware
{
    public class CustomImageCachingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CustomImageCachingMiddleware(RequestDelegate next, IHostingEnvironment hostingEnvironment)
        {
            _next = next;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;

            if (!path.StartsWith("/images") || !int.TryParse(path.Split("/").Last(), out var imageId))
            {
                await _next(context);

                return;
            }

            var webRoot = _hostingEnvironment.WebRootPath;
            var absolutePath = Path.Combine(webRoot, "cached_images", imageId + ".bmp");

            if (File.Exists(absolutePath))
            {
                var bytes = await File.ReadAllBytesAsync(absolutePath);
                await context.Response.Body.WriteAsync(bytes);

                return;
            }

            var originalBody = context.Response.Body;

            try
            {
                using (var ms = new MemoryStream())
                {
                    context.Response.Body = ms;

                    await _next(context);

                    if (context.Response.ContentType == null || context.Response.ContentType != "image/bmp")
                    {
                        return;
                    }

                    ms.Position = 0;
                    await ms.CopyToAsync(originalBody);

                    ms.Position = 0;
                    var cachedImagesDirectoryAbsolutePath = Path.Combine(webRoot, "cached_images");
                    Directory.CreateDirectory(cachedImagesDirectoryAbsolutePath);

                    var imagePath = Path.Combine(cachedImagesDirectoryAbsolutePath, imageId + ".bmp");

                    using (var fileStream = File.Create(imagePath))
                    {
                        await ms.CopyToAsync(fileStream);
                    }
                }

            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }
    }
}
