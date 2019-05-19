using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NorthwindTraders.Adapters.Driving.Web.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "northwind-id")]
    public class NorthwindImageLinkTagHelper : TagHelper
    {
        [HtmlAttributeName("northwind-id")]
        public string ImageId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("href", $"images/{ImageId}");
        }
    }
}