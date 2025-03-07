namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            // Dictionary<string, Product> products = new Dictionary<string, Product>() // new() -- vậy cũng được
            // {
            //     // {
            //     //     "Kayak", new Product {Name = "Kayak", Price = 259M}
            //     // },
            //     // {
            //     //     "Lifejacket", new Product {Name = "Lifejacket", Price = 59.95M}
            //     // }
            //     ["Kayak"] = new Product { Name = "Kayak", Price = 259M },
            //     ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 59.95M }
            // };
            // return View("Index", products.Keys);

            // Product?[] products = Product.GetProducts();
            // return View(new string[] { products[2]?.Name ?? "No value" });
            // #pragma warning disable CS8602
            // return View(new string[] { $"Name: {products[0]?.Name}, Price: {products[0]?.Price}" });

            // object[] data = new object[] { 275M, 29.92M, "apple", "samsung", 100, 10 };
            // decimal total = 0;
            // for (int i = 0; i < data.Length; i++)
            // {
            //     // if (data[i] is decimal d)
            //     // {
            //     //     total += d;
            //     // }
            //     switch (data[i])
            //     {
            //         case decimal decimalValue:
            //             total += decimalValue;
            //             break;
            //         case int intValue when intValue > 50:
            //             total += intValue;
            //             break;
            //     }
            // }

            // return View("index", new string[] { $"Total: {total:C2}" });

            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            Product[] productArray =
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Socer ball", Price = 108.55M },
                new Product { Name = "Corner flag", Price = 23.25M }
            };
            decimal cartTotal = cart.TotalPrices();
            decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();
            return View("Index", new string[] {
                $"Cart Total: {cartTotal:C2}",
                $"Array Total: {priceFilterTotal:C2}",
                $"Name Total: {nameFilterTotal:C2}" });
        }
    }
}