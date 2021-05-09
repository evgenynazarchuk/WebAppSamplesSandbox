using Microsoft.AspNetCore.Mvc;

namespace AppWithViewComponent
{
    [ViewComponent]
    public class Profile : ViewComponent
    {
        public IViewComponentResult Invoke(UserPorfile userProfile)
        {
            return View("_Profile", userProfile);
        }
    }
}
