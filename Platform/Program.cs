using Microsoft.Extensions.Options;
using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<MessageOptions>(options =>
{
    options.CityName = "Hanoi";
});

var app = builder.Build();

// app.Use(async (context, next) =>
// {
//     await next();
//     await context.Response.WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
// });

// app.Use(async (context, next) =>
// {
//     if (context.Request.Path == "/short")
//     {
//         await context.Response.WriteAsync($"Request Short Circuited");
//     }
//     else
//     {
//         await next();
//     }
// });

// app.Use(async (context, next) =>
// {
//     if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
//     {
//         context.Response.ContentType = "text/plain";
//         await context.Response.WriteAsync("Custom Middleware \n");
//     }
//     await next();
// });


// app.Map("/branch", branch =>
// {
//     branch.UseMiddleware<Platform.QueryStringMiddleware>();
//     branch.Use(async (HttpContext context, Func<Task> next) =>
//     {
//         // Middleware của bạn làm gì đó ở đây
//         await context.Response.WriteAsync($"Branch Middleware \n");

//         // Gọi next để tiếp tục với pipeline
//         await next();
//     });
// });


// app.UseMiddleware<Platform.QueryStringMiddleware>();

// app.Map("/location", async (HttpContext context, IOptions<Platform.MessageOptions> options) =>
// {
//     Platform.MessageOptions opts = options.Value;
//     await context.Response.WriteAsync($"{opts.CityName}, {opts.CountryName}");
// });

// app.UseMiddleware<LocationMiddleware>();

// app.UseMiddleware<Population>();
// app.UseMiddleware<Capital>();

// app.UseRouting();
// #pragma warning disable ASP0014
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapGet("/routing", async context =>
//     {
//         await context.Response.WriteAsync("Routing Middleware Reached");
//     });
//     endpoints.MapGet("/population/hochiminh", new Population().Invoke);
//     endpoints.MapGet("/capital/vietnam", new Capital().Invoke);
// });


// app.MapGet("/routing", async context =>
//     {
//         await context.Response.WriteAsync("Routing Middleware Reached");
//     });
// app.MapGet("/population/hochiminh", new Population().Invoke);
// app.MapGet("/capital/vietnam", new Capital().Invoke);

app.UseMiddleware<WeatherMiddleware>();
app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);
IResponseFormatter formatter = new TextResponseFormatter();
app.MapGet("endpoint/function", async context =>
{
    await formatter.Format(context, "Endpoint Function: It is sunny CanTho");
});

// app.Run(async (context) =>
// {
//     await context.Response.WriteAsync("Terminal Middleware Reached");
// });

// app.MapGet("/", () => "Hello World!");

app.Run();