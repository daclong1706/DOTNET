using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebAppMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FormController : Controller
    {
        private readonly DataContext _context;
        public FormController(DataContext context)
        {
            _context = context;
        }
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Index(long id = 1)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
            ViewBag.Suppliers = new SelectList(_context.Suppliers, "SupplierId", "Name");
            return View("Form", await _context.Products.Include(p => p.Category).Include(p => p.Supplier).FirstAsync(p => p.ProductId == id) ?? new() { Name = string.Empty });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitForm(string name, decimal price)
        {
            // foreach (string key in Request.Form.Keys.Where(k => !k.StartsWith("_")))
            // {
            //     TempData[key] = string.Join(", ", (string?)Request.Form[key]);
            // }
            TempData["name param"] = name;
            TempData["price param"] = price;
            return RedirectToAction(nameof(Results));
        }
        public IActionResult Results() { return View(); }
    }
}
