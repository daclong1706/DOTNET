namespace Platform
{
    public class Capital
    {
        private RequestDelegate? next;
        public Capital()
        {

        }
        public Capital(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string[] parts = context.Request.Path.ToString().Split("/", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && parts[0] == "capital")
            {
                string country = parts[1];
                string? capital = country.ToLower() switch
                {
                    "vietnam" => "Hanoi",
                    "uk" => "London",
                    "france" => "Paris",
                    _ => null
                };
                if (capital != null)
                {
                    await context.Response.WriteAsync($"Capital of {country} is {capital}");
                    return;
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync($"Country {country} not found.");
                }
                if (next != null)
                {
                    await next(context);
                }
            }
        }
    }
}