using WebAppMVC.Models;

namespace WebAppMVC
{
    public class TestMiddleWare
    {
        private RequestDelegate nextDelegate;
        public TestMiddleWare(RequestDelegate next) { 
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context, DataContext dataContext)
        {
            if(context.Request.Path == "/test")
            {
                await context.Response.WriteAsync($"There are " + dataContext.Products.Count() + " Poducts\n");
                await context.Response.WriteAsync($"There are " + dataContext.Categories.Count() + " Categories\n");
                await context.Response.WriteAsync($"There are " + dataContext.Suppliers.Count() + " Supliers\n");
            }
            else
            {
                await nextDelegate(context);
            }
        }
    }
}