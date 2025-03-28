
using Microsoft.AspNetCore.Mvc;


namespace WebAppMVC.Controllers
{
    public class CubedController : Controller
    {
        public IActionResult Index()
        {
            return View("Cubed");
        }

        public IActionResult Cube(double num)
        {
            TempData["value"] = num.ToString();
            TempData["result"] = Math.Pow(num, 2).ToString();
            return RedirectToAction(nameof(Index));
        }
    }
}
