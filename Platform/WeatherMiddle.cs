using Microsoft.Extensions.Options;
using Platform;

namespace Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;
        public WeatherMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware/class")
            {
                await context.Response.WriteAsync("Middleware Claas: It is raining in TPHCM");
            }
            else
            {
                await next(context);
            }
        }
    }
}