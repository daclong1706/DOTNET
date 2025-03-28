using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStoreRepository _repository;
    public int pageSize = 4;

    public HomeController(ILogger<HomeController> logger, IStoreRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    // public IActionResult Index(int productPage = 1)
    // {
    //     return View(new ProductsListViewModel
    //     {
    //         Products = _repository.GetProducts()
    //         .OrderBy(p => p.ProductID)
    //         .Skip((productPage - 1) * pageSize)
    //         .Take(pageSize),
    //         PagingInfo = new PagingInfo
    //         {
    //             CurrentPage = productPage,
    //             ItemPerPage = pageSize,
    //             TotalItems = _repository.GetProducts().Count()
    //         }
    //     });
    // }

    public IActionResult Index(string? category, int page = 1)
    {
        var products = _repository.GetProducts();
        var categories = products.Select(p => p.Category).Distinct(); // Lấy danh sách các category duy nhất

        var filteredProducts = products.Where(p => category == null || p.Category == category);

        var model = new ProductsListViewModel
        {
            Products = filteredProducts.Skip((page - 1) * pageSize).Take(pageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemPerPage = pageSize,
                TotalItems = category == null ? products.Count() : filteredProducts.Count()
            },
            SelectedCategory = category
        };

        ViewBag.Categories = new SelectList(categories); // Truyền danh sách categories tới View
                                                         // ViewBag.Categories = new SelectList(
                                                         //     new[] { "All Categories" }.Concat(
                                                         //         _repository.GetProducts().Select(p => p.Category).Distinct()
                                                         //     )
                                                         // );
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
