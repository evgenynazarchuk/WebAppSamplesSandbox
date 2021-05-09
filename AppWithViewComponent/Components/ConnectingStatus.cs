using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AppWithViewComponent
{
    [ViewComponent]
    public class ConnectingStatus : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // dot not use html attributes
            return new ContentViewComponentResult("Connected");
        }
    }
}
