using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Web.TagHelpers
{
    public class EmailBusinessTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //<email-business>philipe</email-business>
            // => <a href="mailto:philipe.formagio@gmail.com">philipe.formagio@gmail.com</a>

            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + ".formagio@" + "gmail.com";
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}
