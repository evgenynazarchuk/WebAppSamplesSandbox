using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AppWithRazorPages.Pages.CustomerManager
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _data;

        public DeleteModel(DataContext data)
        {
            this._data = data;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer customer = await this._data.Customers.FindAsync(id);
            if (customer is not null)
            {
                this._data.Customers.Remove(customer);
                await this._data.SaveChangesAsync();
            }
            return RedirectToPage("./List");
        }
    }
}
