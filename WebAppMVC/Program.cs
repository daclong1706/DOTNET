using Microsoft.EntityFrameworkCore;
using WebAppMVC;
using WebAppMVC.Models;
using Microsoft.AspNetCore.Antiforgery;
using Azure.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<AntiforgeryOptions>(opts =>
{
    opts.HeaderName = "X-XSRF_TOKEN";
});

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection"));
    opts.EnableSensitiveDataLogging(true);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

IAntiforgery antiforgery = app.Services.GetRequiredService<IAntiforgery>();
app.Use(async (context, next) =>
{
    if (!context.Request.Path.StartsWithSegments("/api"))
    {
        string? token = antiforgery.GetAndStoreTokens(context).RequestToken;
        if (token != null)
        {
            context.Response.Cookies.Append("XSRF-TOKEN", token, new CookieOptions { HttpOnly = false });
        }
    }
    await next();
});

app.UseRouting();

//app.UseAuthorization();
app.UseMiddleware<TestMiddleWare>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.Run();

