using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SampleApplication.Extensions
{
    public static class Extensions
    {
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper, string name, string value = "", string placeHolder = "")
        => htmlHelper.TextBox(name, value, new
        {
            style = "color:red;background-color:yellow;font-size=15px",
            @class = "form-input",
            a = "a",
            b = "b",
            placeHolder = placeHolder
        });
    }
}
