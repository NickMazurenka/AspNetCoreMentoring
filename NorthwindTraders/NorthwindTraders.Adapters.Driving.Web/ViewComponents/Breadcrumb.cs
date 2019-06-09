using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindTraders.Adapters.Driving.Web.ViewComponents
{
    public class Breadcrumb : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = new List<(string, string)>();

            var urls = ViewContext.RouteData.Values.Values.Select(x => x.ToString()).ToArray();

            for (int i = 0; i < urls.Length; i++)
            {
                var relativeUrl = "";
                for (int j = 0; j <= i; j++)
                {
                    relativeUrl += $"/{urls[j]}";
                }
                result.Add((urls[i], relativeUrl));
            }

            return View(result);
        }
    }
}
