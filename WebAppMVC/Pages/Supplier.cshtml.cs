using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models;

namespace WebAppMVC.Pages
{
    public class SupplierModel : PageModel
    {
        private readonly DataContext dataConext;
        public Supplier Supplier { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public SupplierModel(DataContext dataConext)
        {
            this.dataConext = dataConext;
        }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id.HasValue)
            {
                Supplier = await dataConext.Suppliers.FindAsync(id);
                if (Supplier == null)
                {
                    return NotFound();
                }
            }
            else
            {
                Suppliers = await dataConext.Suppliers.ToListAsync();
            }
            return Page();
        }
    }
}