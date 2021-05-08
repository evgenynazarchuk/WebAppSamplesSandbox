using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppWithRazorPages.Pages.CustomerManager
{
    public class AddModel : PageModel
    {
        private readonly DataContext _data;

        public AddModel(DataContext data)
        {
            this._data = data;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost([FromForm]Customer customer)
        {
            this._data.Customers.Add(customer);
            await this._data.SaveChangesAsync();
            return RedirectToPage("./List");
        }
    }
}
