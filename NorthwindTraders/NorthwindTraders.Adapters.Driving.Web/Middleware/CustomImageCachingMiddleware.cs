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
            var servedImage = false;
            if (path.StartsWith("/images"))
            {
                var t = int.TryParse(path.Split("/").Last(), out var id);
                if (t)
                {
                    var webRoot = _hostingEnvironment.WebRootPath;
                    var absolutePath = Path.Combine(webRoot, "cached_images", id + ".bmp");
                    if (File.Exists(absolutePath))
                    {
                        var bytes = await File.ReadAllBytesAsync(absolutePath);
                        await context.Response.Body.WriteAsync(bytes);
                        servedImage = true;
                    }
                }
            }

            if (!servedImage)
            {
                var webRoot = _hostingEnvironment.WebRootPath;
                var cachedImagesDirectoryAbsolutePath = Path.Combine(webRoot, "cached_images");
                Directory.CreateDirectory(cachedImagesDirectoryAbsolutePath);

                await _next(context);

                var contentType = context.Response.ContentType;
                if (contentType != null && contentType == "image/bmp")
                {
                    if (int.TryParse(path.Split("/").Last(), out var id))
                    {
                        var imagePath = Path.Combine(cachedImagesDirectoryAbsolutePath, id + ".bmp");

                        using (var fileStream = File.Create(imagePath))
                        {
                            await context.Response.Body.CopyToAsync(fileStream);
                        }
                    }
                }
            }
        }
    }
}
