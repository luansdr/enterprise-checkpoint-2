using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Web.Aula02.TagHelpers
{
    public class ButtonCustomTagHelper : TagHelper
    {
        public string Label { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
      

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";

            switch (Color)
            {
                case "primary":
                    output.Attributes.SetAttribute("class", "btn btn-primary");
                    break;
                case "secondary":
                    output.Attributes.SetAttribute("class", "btn btn-secondary");
                    break;
                case "success":
                    output.Attributes.SetAttribute("class", "btn btn-success");
                    break;
                case "info":
                    output.Attributes.SetAttribute("class", "btn btn-info text-white");
                    break;
                case "light":
                    output.Attributes.SetAttribute("class", "btn btn-light");
                    break;
                case "link":
                    output.Attributes.SetAttribute("class", "btn btn-link");
                    break;
                case "danger":
                    output.Attributes.SetAttribute("class", "btn btn-danger");
                    break;
                default:
                    output.Attributes.SetAttribute("class", "btn btn-secondary");
                    break;
            }
            if (!string.IsNullOrEmpty(Icon))
            {
                var icon = new TagBuilder("i");
                icon.AddCssClass(Icon);
                output.Content.AppendHtml(icon);
                output.Content.Append(" "); 
            }

            output.Content.Append(Label);
        }
    }

}
