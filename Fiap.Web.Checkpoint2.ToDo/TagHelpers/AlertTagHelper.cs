﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Drawing;
using System.Reflection.Emit;

namespace Fiap.Web.Aula02.TagHelpers
{
    public class AlertTagHelper : TagHelper
    {

        public String? Mensagem { get; set; }
        public String? Color { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if (!string.IsNullOrEmpty(Mensagem))
            {
                output.TagName = "div";
                output.Content.SetContent(Mensagem);

                switch (Color)
                {
                    case "primary":
                        output.Attributes.SetAttribute("class", "alert alert-primary");
                        break;
                    case "secondary":
                        output.Attributes.SetAttribute("class", "alert alert-secondary");
                        break;
                    case "success":
                        output.Attributes.SetAttribute("class", "alert alert-success");
                        break;
                    case "danger":
                        output.Attributes.SetAttribute("class", "alert alert-danger");
                        break;
                    default:
                        output.Attributes.SetAttribute("class", "alert alert-info");
                        break;
                }
            }
         
        }
    }
}
