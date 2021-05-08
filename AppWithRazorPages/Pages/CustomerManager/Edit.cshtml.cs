using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppWithRazorPages.Pages.CustomerManager
{
    public class EditModel : PageModel
    {
        private readonly DataContext _data;
        public Customer Customer { get; set; }

        public EditModel(DataContext data)
        {
            this._data = data;
        }

        public async Task OnGetAsync(int id)
        {
            this.Customer = await this._data.Customers.FindAsync(id);
        }

        public async Task<IActionResult> OnPost([FromForm]Customer customer)
        {
            this._data.Customers.Update(customer);
            await this._data.SaveChangesAsync();

            return RedirectToPage("./List");
        }
    }
}
