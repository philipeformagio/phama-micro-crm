using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Web.TagHelpers
{
    public class EmailBusinessTagHelper : TagHelper
    {
        public string EmailDomain { get; set; } = "dev.io";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //<email-business>philipe</email-business>
            //  => <a href="mailto:philipe.formagio@dev.io">philipe.formagio@gmail.com</a>

            //<email-business email-domain="gmail.com">support</email-business>
            //  => <a href="mailto:support.formagio@gmail.com">philipe.formagio@gmail.com</a>

            output.TagName = "a";
            var content = await output.GetChildContentAsync();

            string target;
            if (EmailDomain == "gmail.com")
                target = content.GetContent() + ".formagio@" + EmailDomain;
            else
                target = content.GetContent() + "@" + EmailDomain;
            
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}
