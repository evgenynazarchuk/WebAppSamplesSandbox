using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AppWithHtmlHelpers
{
    public static class HtmlHelpers
    {
        public static HtmlString PrintList(this IHtmlHelper page, IReadOnlyCollection<string> list)
        {
            string html;
            html = "<div>";
            foreach (var item in list)
            {
                html = $"{html}{item}<br/>";
            }
            html = $"{html}</div>";
            return new HtmlString(html);
        }
    }
}
