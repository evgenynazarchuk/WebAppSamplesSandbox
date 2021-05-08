using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppWithRazorPages.Pages.CustomerManager
{
    public class ListModel : PageModel
    {
        private readonly DataContext _data;
        public List<Customer> Customers { get; set; }

        public ListModel(DataContext data)
        {
            this._data = data;
        }

        public async Task OnGetAsync()
        {
            this.Customers = await this._data.Customers.AsNoTracking().ToListAsync();
        }
    }
}
