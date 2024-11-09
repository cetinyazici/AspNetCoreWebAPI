﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SampleApplication.TagHelpers
{
    [HtmlTargetElement("email-tag-helpers")]
    //Burada bir isim belirtmezsek default olarak class ismi neyse TagHelperimizin ismide o olur.
    public class EmailTagHelper : TagHelper
    {
        public string Mail { get; set; }
        public string Display { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", $"mailto:{Mail}");
            output.Content.Append(Display);
        }
    }
}
