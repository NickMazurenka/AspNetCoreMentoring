using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NorthwindTraders.Adapters.Driving.Web.HtmlHelpers
{
    public static class NorthwindImageHtmlHelper
    {
        public static IHtmlContent NorthwindImage(this IHtmlHelper htmlHelper, int imageId, string imageText)
            => new HtmlString($"<img src=\"images/{imageId}\" alt=\"{imageText}\">");
    }
}
