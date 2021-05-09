using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;

namespace AppWithViewComponent
{
    [ViewComponent]
    public class Time : ViewComponent
    {
        private readonly ITimeService _time;
        public Time(ITimeService time)
        {
            this._time = time;
        }

        public IViewComponentResult Invoke()
        {
            // use html attributes
            var html = new HtmlString("<b>" + this._time.GetTime() + "</b>");
            return new HtmlContentViewComponentResult(html);
        }
    }
}
