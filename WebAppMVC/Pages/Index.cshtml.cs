using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppMVC.Models;

namespace WebAppMVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataContext dataConext;
        public Product Product { get; set; }
        public IndexModel(DataContext dataConext)
        {
            this.dataConext = dataConext;
        }
        public async Task OnGetAsync(long id = 1)
        {
            Product = await dataConext.Products.FindAsync(id);
        }
    }
}
