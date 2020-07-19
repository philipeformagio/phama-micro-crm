using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Web.TagHelpers
{
    public class TelephoneTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "text";

            var content = await output.GetChildContentAsync();

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("(" + content.GetContent().Substring(0, 2) + ") ");

            if (content.GetContent().Substring(2, 1) == "9")
            {
                builder.Append(content.GetContent().Substring(2, 5));
                builder.Append("-");
                builder.Append(content.GetContent().Substring(7, 4));
            }
            else
            {
                builder.Append(content.GetContent().Substring(2, 4));
                builder.Append("-");
                builder.Append(content.GetContent().Substring(6, 4));
            }

            var target = builder.ToString();

            output.Content.SetContent(target);
        }
    }
}
