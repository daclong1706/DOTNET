namespace Platform
{
    public class WeatherEndpoint
    {
        public static async Task Endpoint(HttpContext context)
        {
            await context.Response.WriteAsync("Endpoint Claas: It is sunshine in HaNoi");
        }
    }
}