using Microsoft.Extensions.Options;
using Platform;

namespace Platform
{
    public class QueryStringMiddleware
    {
        private RequestDelegate next;
        public QueryStringMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync("Class Middleware \n");
            }
            await next(context);
        }
    }

    public class LocationMiddleware
    {
        private RequestDelegate next;
        private MessageOptions options;
        public LocationMiddleware(RequestDelegate next, IOptions<MessageOptions> options)
        {
            this.next = next;
            this.options = options.Value;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/location")
            {
                await context.Response.WriteAsync($"{options.CityName}, {options.CountryName}");
            }
            else
            {
                await next(context);
            }
        }
    }
}