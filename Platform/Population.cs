namespace Platform
{
    public class Population
    {
        private RequestDelegate? next;
        public Population()
        {

        }
        public Population(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string[] parts = context.Request.Path.ToString().Split("/", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && parts[0] == "population")
            {
                string city = parts[1];
                int? population = city.ToLower() switch
                {
                    "hanoi" => 8_000_000,
                    "hochiminh" => 12_000_000,
                    "cantho" => 4_000_000,
                    "paris" => 2_000_000,
                    "beijing" => 21_000_000,
                    "washington" => 12_000_000,
                    "backinh" => 100_000_000,
                    _ => null
                };
                if (population.HasValue)
                {
                    await context.Response.WriteAsync($"Population of {city} is {population}");
                    return;
                }
                if (next != null)
                {
                    await next(context);
                }
            }
        }
    }
}