using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace OverrideActionResult
{
    public class HtmlBlockResult : IActionResult
    {
        private readonly string _html;

        public HtmlBlockResult(string html)
        {
            this._html = html;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            string htmlResult = "<div>" + this._html + "</div>";
            await context.HttpContext.Response.WriteAsync(htmlResult);
        }
    }
}
